using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingChallenge.Entities;

namespace CodingChallenge.Services
{
    public interface ICosmosDbService
    {
        Task<ContactEntity> GetContactAsync(Guid id);
        Task AddContactAsync(ContactEntity contact);
        Task UpdateContactAsync(Guid id, ContactEntity contact);
    }
}