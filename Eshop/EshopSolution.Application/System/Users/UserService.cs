using EshopSolution.Data.Entities;
using EshopSolution.Utilities.Exceptions;
using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
       // private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                             IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new ApiErrorResult<string>("Tên đăng nhập không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string> ("Mật khẩu không chính xác");
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
              _configuration["Tokens:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(180),
              signingCredentials: credentials);

            return new ApiSuccessResult<string>( new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            //1.Query
            var query = _userManager.Users;
            if(!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                                      || x.PhoneNumber.Contains(request.Keyword)
                                      || x.FirstName.Contains(request.Keyword)
                                      || x.LastName.Contains(request.Keyword)
                                      || x.Email.Contains(request.Keyword)
                                      || x.Dob.ToString().Contains(request.Keyword));
                                      
            }

            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Dob = x.Dob,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber

                }).ToListAsync();

            //4.Select and Projection
            var pageResult = new PageResult<UserViewModel>()
            {
                TotalRecord = totalRow,
                Item = await data,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };

            return new ApiSuccessResult<PageResult<UserViewModel>>(pageResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tên đăng nhập đã tồn tại") ;
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Email đã được sử dụng cho tài khoảng khác");
            }
            if((!string.IsNullOrEmpty(request.PhoneNumber)) &&  _userManager.Users.Where(user => user.PhoneNumber == request.PhoneNumber).FirstOrDefault() !=null)
            {
                return new ApiErrorResult<bool>("Số điện thoại đã được sử dụng cho tài khoảng khác");
            }
            user = new AppUser()
            {
              
                Dob = request.Dob,
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng kí không thành công");
        }
        public async Task<ApiResult<bool>> Update(Guid id , UpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            //if (_userManager.Users.Where(user => user.PhoneNumber == request.PhoneNumber && user.Id != id).FirstOrDefault() != null && 
            //    !string.IsNullOrEmpty(request.PhoneNumber))
            //{
            //    return new ApiErrorResult<bool>("Số điện thoại đã được sử dụng cho tài khoảng khác");
            //}
            var user = await _userManager.FindByIdAsync(id.ToString());
            
                user.Dob = request.Dob;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            { 
                return new ApiSuccessResult<bool>();
            }else 
              return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            //1.Query
            var user =  _userManager.Users.Where(user => user.Id == id).FirstOrDefault();
            if(user == null)
            {
                return new ApiErrorResult<UserViewModel>("Không tìm thấy User");
            }
            var data = new UserViewModel()
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Dob = user.Dob,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

            };

            return new ApiSuccessResult<UserViewModel>(data);
        }

        public async Task<ApiResult<bool>> Delete(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString()) ;
            if(user ==null)
            {
                return new ApiErrorResult<bool>("Người dùng không tồn tại !");
            }
            var result = await _userManager.DeleteAsync(user);
            if(result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Xóa không thành công");

        }
    }
}