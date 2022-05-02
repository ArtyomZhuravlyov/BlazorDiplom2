using BlazorDiplom2.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BlazorDiplom2.Data
{
    public class DB : IdentityDbContext<AspNetUsers>
    {
        public DbSet<Group> Groups { get; set; }
        //   public DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Koan> Koans { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<KoanInModule> KoanInModules { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<KoanInTest> KoanInTests { get; set; }


        public DbSet<ResultTest> ResultTests { get; set; }

        public DbSet<ResultKoanTest> ResultKoanTests { get; set; }

        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }

        public static bool StatusStart = false;

        

        //RegisterModel _regM { get; set; }
        //[Inject]
        //RoleManager<IdentityRole> _roleManager;

        //[Inject]
        //public UserManager<AspNetUsers> _userManager { get; set; }
        //[Inject]
        //public IUserStore<AspNetUsers> _userStore { get; set; }

        ////public readonly SignInManager<AspNetUsers> _signInManager;

        public DB(DbContextOptions<DB> options
          //, 
          //RoleManager<IdentityRole> roleManager,
          //UserManager<AspNetUsers> userManager
          ////SignInManager<AspNetUsers> signInManager
          )
            : base(options)
        {
            // _regM = registerModel;
            //_roleManager = roleManager;
            //_userManager = userManager;
            //_signInManager = signInManager;



            //Groups.Add(new Group()
            //{
            //    Name = "Test"
            //});
            //SaveChanges();


            //var user = Activator.CreateInstance<AspNetUsers>();


            // await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<AspNetUsers>()
        //    //    .HasOne(u => u.Student)
        //    //    .WithOne(s => s.AspNetUser)
        //    //    .HasForeignKey<Student>(s => s.AspNetUsersId);
        //    ////.OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<AspNetUsers>(entity =>
        //    {
        //        entity.HasOne(u => u.Student)
        //            .WithOne(p => p.AspNetUser)
        //            .HasForeignKey<Student>(d => d.AspNetUsersId);

        //        entity.HasOne(u => u.Teacher)
        //            .WithOne(p => p.AspNetUser)
        //            .HasForeignKey<Teacher>(d => d.AspNetUsersId);
        //    });

        //    // использование Fluent API
        //    base.OnModelCreating(modelBuilder);

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<KoanInModule>(entity =>
        //    //{
        //    //    entity.HasMany(u => u.Students)
        //    //        .WithMany(p => p.KoanInModules)
        //    //        .UsingEntity(j => j.ToTable("KoanInModulesStudents1"));
        //    //        //.OnDelete(DeleteBehavior.Cascade);
        //    //    //  .HasForeignKey<Student>(d => d.AspNetUsersId);

        //    //    //entity.HasOne(u => u.Teacher)
        //    //    //    .WithOne(p => p.AspNetUser)
        //    //    //    .HasForeignKey<Teacher>(d => d.AspNetUsersId);
        //    //});
        //    //base.OnModelCreating(modelBuilder);
        //}

        public void SetDefValue()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }


        public IEnumerable<Group> GetGroups()
        {
            return Groups;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await Task.FromResult(Teachers.Include(x => x.AspNetUser));
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await Task.FromResult(Students.Include(x => x.AspNetUser));
            //return await Task.FromResult(Students.Include(x => x.AspNetUser));
        }

        //public async Task<IEnumerable<Universities>> GetUniversitiesAsync()
        //{
        //    return await Task.FromResult(EducationalInstitutions.Include(x=>x.));
        //}

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await Task.FromResult(Groups);
        }

        //public async Task<AspNetUsers> GetCurrentUserAsync()
        //{
        //    var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
        //    var user = authstate.User;
        //    return await _userManager.GetUserAsync(user);
        //}

    }

}
