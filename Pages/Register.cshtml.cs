using System.Text.Json;
using AnkAUTH_Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnkaAUTH_Server.Pages;

public class RegisterModel : PageModel
{
        private UserManager<ApplicationUser> _userManager;
        public bool EmailReady { get; set; }
        public bool PasswordInvalid { get; set; }
        public bool RePasswordInvalid { get; set; }
        public bool EmailInvalid { get; set; }

        public string EmailValidation { get; set; }
        public string PasswordValidation { get; set; }
        public string RePasswordValidation { get; set; }
        public bool IsRegisterSuccess { get; set; }

        public bool IsShowMessage { get; set; }
        public string MessageText { get; set; }

        public RegisterDataModel DataModel {get;set;}

        public RegisterModel(UserManager<ApplicationUser> userManager)
        {
                EmailInvalid = false;
                _userManager = userManager;
                DataModel = new RegisterDataModel();
        }

        public void OnGet()
        {
        }

        public async Task OnPostRegister(RegisterDataModel model)
        {
                DataModel = model;
                EmailReady = true;

                if (!model.Password.Equals(model.RePassword))
                {
                        RePasswordInvalid = true;
                        PasswordInvalid = true;
                        PasswordValidation = "Passwords do not match !";
                        RePasswordValidation = "Passwords do not match !";
                        return;
                }
                ApplicationUser new_user = new ApplicationUser()
                {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Email
                };

                IdentityResult res = await _userManager.CreateAsync(new_user, model.Password);
                if (res.Succeeded)
                {
                      IsRegisterSuccess = true;
                      showMessage("Kayýt Baþarlýdýr.\n Giriþ Ekranýna Yönlendiriliyorsunuz...");
                }else{
                      
                      checkValidations(res);
                      Console.WriteLine(JsonSerializer.Serialize(res));  
                }
        }

        private void checkValidations(IdentityResult res){
                
                PasswordValidation = "";
                List<string> passwordError = new List<string>();
                foreach (var error in res.Errors)
                {
                        if(error.Code.ToLower().StartsWith("password"))
                        {
                                PasswordInvalid = true;
                                passwordError.Add(error.Description);
                        }      
                }

                if(passwordError.Count > 0)
                {
                        PasswordValidation = String.Join("\n",passwordError);
                        DataModel.RePassword = "";
                }
        }

        public async Task OnPostEmailValidation(RegisterDataModel model)
        {     
                if(model.Email != null){
                        DataModel = model;
                        var res = await _userManager.FindByEmailAsync(model.Email);
                        if (res != null)
                        {
                                EmailReady = false;
                                EmailInvalid = true;
                                EmailValidation = $"{model.Email} already registered.";
                        }
                        else
                        {
                                EmailInvalid = false;
                                EmailReady = true;
                        }
                }
                else
                {
                        EmailInvalid = false;
                        EmailReady = true;
                }
        }

        private void showMessage(string message){
                IsShowMessage = true;
                MessageText = message;
        }
}