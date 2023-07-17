using System.ComponentModel.DataAnnotations;

public class UserModel
{
    //public Guid ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class RegisterModel  
{  
    [Required(ErrorMessage = "User Name is required")]  
    public string Username { get; set; }  

    [EmailAddress]  
    [Required(ErrorMessage = "Email is required")]  
    public string Email { get; set; }  

    [Required(ErrorMessage = "Password is required")]  
    public string Password { get; set; }  
} 
public class LoginModel  
{  
    [Required(ErrorMessage = "User Name is required")]  
    public string Username { get; set; }  

    [Required(ErrorMessage = "Password is required")]  
    public string Password { get; set; }  
}

public class Response  
{  
    public string Status { get; set; }  
    public string Message { get; set; }  
} 