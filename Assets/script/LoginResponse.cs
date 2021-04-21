public class LoginResponse: ResponseStruct 
{
	public LoginData data{get; set;}
}

public class LoginData
{
	public string token{get; set;}
}
