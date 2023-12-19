using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstracts;
using DataAccess.Concrete.Entityframework;
using DataAccess.Concretes;

namespace Business.DependencyRevolvers.Autofac
{
    // Autofac Kullanılarak sınıfları newlemeden kullanmak için IoC
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // İstenilen referansa göre bir sınıf oluşturuyor

            builder.RegisterType<OptionManager>().As<IOptionService>();
            builder.RegisterType<EfOptionDal>().As<IOptionDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<QuizManager>().As<IQuizService>();
            builder.RegisterType<EfQuizDal>().As<IQuizDal>();

            builder.RegisterType<QuizScoreManager>().As<IQuizScoreService>();
            builder.RegisterType<EfQuizScoreDal>().As<IQuizScoreDal>();

            builder.RegisterType<TotalScoreManager>().As<ITotalScoreService>();
            builder.RegisterType<EfTotalScoreDal>().As<ITotalScoreDal>();

            builder.RegisterType<QuestionManager>().As<IQuestionService>();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();

            builder.RegisterType<RecomendedQuizManager>().As<IRecomendedQuizService>();
            builder.RegisterType<EfRecomendedQuizDal>().As<IRecomendedQuizDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}