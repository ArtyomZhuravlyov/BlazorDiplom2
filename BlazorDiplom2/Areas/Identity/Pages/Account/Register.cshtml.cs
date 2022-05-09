// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using BlazorDiplom2.Data;

namespace BlazorDiplom2.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly SignInManager<AspNetUsers> _signInManager;
        public readonly UserManager<AspNetUsers> _userManager;
        public readonly IUserStore<AspNetUsers> _userStore;
        public readonly IUserEmailStore<AspNetUsers> _emailStore;
        public readonly ILogger<RegisterModel> _logger;
        public readonly IEmailSender _emailSender;
        public readonly DB _db;
        public RegisterModel(
            DB dB,
            RoleManager<IdentityRole> roleManager,
            UserManager<AspNetUsers> userManager,
            IUserStore<AspNetUsers> userStore,
            SignInManager<AspNetUsers> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _db = dB;
            _roleManager = roleManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [DataType(DataType.Text)]
            [Display(Name = "SurName")]
            public string SurName { get; set; }
        }


        public async /*Task*/Task<IActionResult> OnGetAsync(string returnUrl = null)
        {



            //ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            EducationalInstitution educationalInstitution = new EducationalInstitution()
            {
                FullName = "primer",
                ShortName = "pr"
            };
            _db.EducationalInstitutions.Add(educationalInstitution);

            Group group3 = new Group()
            {
                Name = "Test3",
                EducationalInstitution = educationalInstitution
            };
            _db.Groups.Add(group3);

            Course course3 = new Course()
            {
                Name = "c#23",
                Description = "Opisanie2"
            };
            _db.Courses.Add(course3);

            /////
            var user5 = CreateUser();
            Teacher t5 = new Teacher() { FirstName = "Артём5", LastName = "Zhuravlev5", FatherName="othce"};
            t5.Courses.Add(course3);
            t5.Groups.Add(group3);
            t5.AspNetUser = user5;
            _db.Teachers.Add(t5);
            await _userStore.SetUserNameAsync(user5, "bbbb@mail.ru", CancellationToken.None);
            var result5 = await _userManager.CreateAsync(user5, "3a22f5c9");

          
            
            /////

            Group group = new Group()
            {
                Name = "Test",
                EducationalInstitution = educationalInstitution
            };
            _db.Groups.Add(group);

            Course course = new Course()
            {
                Name = "c#",
                Description = "Opisanie"
            };
            _db.Courses.Add(course);

            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, "art@mail.ru", CancellationToken.None);
            Teacher t = new Teacher() { FirstName = "Артём", LastName = "Zhuravlev", FatherName = "othce" };
            t.Courses.Add(course);
            t.Groups.Add(group);
            t.AspNetUser = user;
            _db.Teachers.Add(t);
            var result = await _userManager.CreateAsync(user, "3a22f5c9");

            ///////
            ///


            Group group2 = new Group()
            {
                Name = "Test2",
                EducationalInstitution = educationalInstitution
            };
            _db.Groups.Add(group2);

         

            Course course2 = new Course()
            {
                Name = "c#2",
                Description = "Opisanie2"
            };
            _db.Courses.Add(course2);

            var user2 = CreateUser();
            await _userStore.SetUserNameAsync(user2, "art2@mail.ru", CancellationToken.None);
            Teacher t2 = new Teacher() { FirstName = "Руководитель2", LastName = "Zhuravlev", FatherName = "othce" };
            t2.Courses.Add(course2);
            t2.Groups.Add(group2);
            t2.AspNetUser = user2;
            _db.Teachers.Add(t2);
            var result2 = await _userManager.CreateAsync(user2, "3a22f5c91");


            var user3Student = CreateUser();
            await _userStore.SetUserNameAsync(user3Student, "artStudent@mail.ru", CancellationToken.None);
            Student student = new Student();
            student.Group = group;
            student.FirstName = "Artyom";
            student.LastName = "Zhuravlew";
            student.FatherName = "othce";
            student.AspNetUser = user3Student;
            _db.Students.Add(student);
            var result3 = await _userManager.CreateAsync(user3Student, "3a22f5c9");


            var user4Student = CreateUser();

           
            //user.SurName = "Zhuravlev";

           
            //user2.SurName = "Zhuravlev2";

            //user3Student.SurName = "StudentZhuravlev";

            await _userStore.SetUserNameAsync(user4Student, "art4Student@mail.ru", CancellationToken.None);
            //user4Student.SurName = "StudentZhuravlev4";

     


           


            

   

            Student student2 = new Student();
            student2.Group = group;
            student2.FirstName = "Adilya";
            student2.LastName = "Kalimullina";
            student2.FatherName = "othce";
            student2.AspNetUser = user4Student;
            _db.Students.Add(student2);
            var result4 = await _userManager.CreateAsync(user4Student, "3a22f5c9");







            //  await _emailStore.SetEmailAsync(user2, "art2@mail.ru", CancellationToken.None);


            //  await _emailStore.SetEmailAsync(user3Student, "artStudent2@mail.ru", CancellationToken.None);


            //  await _emailStore.SetEmailAsync(user4Student, "artStudent4@mail.ru", CancellationToken.None);


            //user.Teacher = t;
            //user2.Teacher = t2;
            //user3Student.Student = student;
            //user4Student.Student = student2;

            //_db.Roles.AddRange(new IdentityRole("Administrators"), new IdentityRole("Teacher"), new IdentityRole("Students"));
            await _roleManager.CreateAsync(new IdentityRole(Constants.ROLE_ADMINISTRATOR_IDENTITY));
            await _roleManager.CreateAsync(new IdentityRole(Constants.ROLE_TEACHER_IDENTITY));
            await _roleManager.CreateAsync(new IdentityRole(Constants.ROLE_STUDENT_IDENTITY));

   
           

            //Input.SurName;
            //user.Group = _db.Groups.First(x => x.Name == "Test");
            //var user2 = new AspNetUsers { UserName = Input.SurName };
            // await _emailStore.SetEmailAsync(user, "art@mail.ru", CancellationToken.None);



            //List<string> roles = new List<string>();
            //roles.Add("Administrators");

            //await _userManager.AddToRoleAsync(user, "Administrators");//.AddToRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, "Administrators");
            await _userManager.AddToRoleAsync(user2, "Teachers");
            await _userManager.AddToRoleAsync(user3Student, "Students");
            await _userManager.AddToRoleAsync(user4Student, "Students");

            await _signInManager.SignInAsync(user, isPersistent: false);

            return LocalRedirect(Url.Content("~/"));
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                if (_db.Groups.FirstOrDefault(x => x.Name == "Test") == null)
                {
                    _db.Groups.Add(new Group()
                    {
                        Name = "Test"
                    });
                    await _db.SaveChangesAsync();
                }

                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
               // user.SurName = "ggg"; //Input.SurName;
                //user.Group = _db.Groups.First(x => x.Name == "Test");
                //var user2 = new AspNetUsers { UserName = Input.SurName };
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (_roleManager.Roles.Where(x => x.Name == "Administrators").Count() == 0)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Administrators"));
                    await _roleManager.CreateAsync(new IdentityRole("Students"));
                    await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                    List<string> roles = new List<string>();
                    roles.Add("Administrators");

                    await _userManager.AddToRolesAsync(user, roles);
                }
                else
                {
                    List<string> roles = new List<string>();
                    roles.Add("Students");
                    await _userManager.AddToRolesAsync(user, roles);
                }






                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private AspNetUsers CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AspNetUsers>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AspNetUsers)}'. " +
                    $"Ensure that '{nameof(AspNetUsers)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<AspNetUsers> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AspNetUsers>)_userStore;
        }
    }
}
