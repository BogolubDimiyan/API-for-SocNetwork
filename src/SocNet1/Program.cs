using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SocNet1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            builder.Services.AddDbContext<Domain.Models.SocialNetContext>(
                options => options.UseSqlServer("Server=DESKTOP-SRKQPQK;Database=SocialNet;User Id=DESKTOP-SRKQPQK\\���;Integrated Security=True;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IPostTagService, PostTagService>();
            builder.Services.AddScoped<IPrivacySettingService, PrivascySettingService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<ILikeService, LikeService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IGroupMemberService, GroupMemberService>();
            builder.Services.AddScoped<IFriendService, FriendService>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventAttendeeService, EventAttendeeService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IBlockedUserService, BlockedUserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "���������� ���� API",
                    Description = "API ��������� ��� ���������� ����",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "������ ��������",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "������ ��������",
                        Url = new Uri("https://example.com/license")
                    }

                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}