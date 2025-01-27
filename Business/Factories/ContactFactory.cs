﻿using System.Diagnostics;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;
//A menu item that creates a contact.
public static class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }
    public static Contact Create(BaseRegistrationForm registrationForm)
    {

        return new Contact
        {
            Id= IdGenerator.GenerateUniqueId(),
            FirstName = registrationForm.FirstName,
            LastName = registrationForm.LastName,
            Email = registrationForm.Email,
            Locality = registrationForm.Locality,
            IsRegistered = registrationForm.IsRegistered()
        };
    }
}
