using CirsaHackaton;
using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace CirsaHackaton.Services
{
    public class UserService
    {
        private List<User> dummyUsersDatabase = new List<User>();
        private List<AffiliateStyle> dummyStylesDatabase = new List<AffiliateStyle>();
        private User? loggedUser;


        //Initialization
        public void InitializeDummyDB()
        {
            User testUser = new User(
                "c432ff01-b4ef-4490-b376-0abdc98e8f3f000",
                "Testing",
                "Tests",
                "testuser@example.com",
                "123456789"
            );

            dummyUsersDatabase.Add(testUser);

            AffiliateStyle testStyle = new AffiliateStyle(
                testUser.GetId(),
                " \U0001fa85\"🎉🎈Bienvenido Meow!🎈🎉\U0001fa85\"",
            "Regístrate con tu correo para obtener las siguientes ventajas!" +
            "\n\n" +
            "Cat ipsum dolor sit amet, panther so bombay yet cornish rex and turkish angora." +
            "Lynx siberian for mouser abyssinian or british shorthair, " +
            "or devonshire rex.Tiger tomcat norwegian forest so lion bobcat and siberian." +
            "Tiger birman but leopard.Mouser siberian cheetah ocicat yet jaguar but donskoy." +
            "Kitten cheetah so birman singapura.Siberian maine coon and cougar kitty.Tomcat tom.",
            "https://img.freepik.com/premium-vector/funny-cute-cats-seamless-pattern-childish-animal-white-repeat-background-simple-pets-ornament-wallpaper-wrapping-paper-modern-trendy-hand-drawn-vector-illustration-flat-cartoon-style_318237-342.jpg?w=826",
                "https://images.unsplash.com/photo-1602779717364-d044d7492ed7?q=80&w=2154&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            );

            dummyStylesDatabase.Add(testStyle);
        }


        //Getters
        public List<User> GetUsers() { return dummyUsersDatabase; }
        public User? GetLoggedUser() { return loggedUser; }
        public User? GetUserById(String uid) { return dummyUsersDatabase.Find(user => user.GetId().Equals(uid)); }
        public User? GetUserByMail(String mail) { return dummyUsersDatabase.Find(user => user.GetMail().Equals(mail)); }
        public AffiliateStyle? GetAffiliateStyle(String affiliateUid) { return dummyStylesDatabase.Find(style => style.GetAffiliateUid().Equals(affiliateUid)); }


        //Profile functions
        public Tuple<bool, String> TryRegisterUser(User user)
        {
            //Validations 
            if (String.IsNullOrEmpty(user.GetName())) 
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado un nombre");

            if (String.IsNullOrEmpty(user.GetSurnames()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ningún apellido");

            if (String.IsNullOrEmpty(user.GetMail()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ningún correo electrónico");

            if (!IsMailValid(user.GetMail()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado un correo electrónico váido");

            if (GetUserByMail(user.GetMail()) != null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: Este email ya se encuentra registrado");

            if (String.IsNullOrEmpty(user.GetPassword()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ninguna contraseña");

            if (user.GetPassword().Length < 8)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña debe de tener al menos 8 caracteres");

            dummyUsersDatabase.Add(user);

            //Log user when success
            loggedUser = user;

            return new Tuple<bool, string>(true, "Registro completado!");
        }

        public Tuple<bool, String> TryLoginUser(String mail, String password) {

            if (String.IsNullOrEmpty(mail))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ningún correo electrónico");

            User? retrievedUser = GetUserByMail(mail);

            if (retrievedUser == null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No existe ningún usuario con este correo");

            if (String.IsNullOrEmpty(password))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ninguna contraseña");

            if (password.Length < 8)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña debe de tener al menos 8 caracteres");

            if (!password.Equals(retrievedUser.GetPassword()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña es incorrecta");

            //Log user when success
            loggedUser = retrievedUser;

            return new Tuple<bool, string>(true, "Sesión iniciada!");
        }


        //Tools
        private static bool IsMailValid(String email)
        {
            var attr = new EmailAddressAttribute();
            return attr.IsValid(email);
        }
    }
}
