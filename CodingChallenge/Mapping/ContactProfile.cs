using System;
using AutoMapper;
using CodingChallenge.Commands.CreateContact;
using CodingChallenge.Commands.UpdateContact;
using CodingChallenge.Entities;
using CodingChallenge.Models;

namespace CodingChallenge.Mapping
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactEntity, ContactDto>()
                .ForMember(d => d.FullName, d => d.MapFrom(x => $"{x.FirstName} {x.EmailAddress}"));

            CreateMap<CreateContactCommand, ContactEntity>()
                .ForMember(d => d.Id, d => Guid.NewGuid())
                .ForMember(d => d.EmailAddress, d => d.MapFrom(x => x.Email))
                .ForMember(d => d.PhoneNumber, d => d.MapFrom(x => x.Phone));

            CreateMap<UpdateContactCommand, ContactEntity>();

            CreateMap<CreateContactRequest, CreateContactCommand>();
            CreateMap<UpdateContactRequest, UpdateContactCommand>();
        }
    }
}
