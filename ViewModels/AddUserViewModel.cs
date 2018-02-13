using System;
using UserSignup.Models;

public class AddUserViewModel
{
    public User User { get; set; }

    public AddUserViewModel()
	{
        User = new User();

	}
}
