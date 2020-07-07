namespace CodingChallenge.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CodingChallenge.Entities;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Fluent;
    using Microsoft.Extensions.Configuration;

    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddContactAsync(ContactEntity contact)
        {
            await this._container.CreateItemAsync<ContactEntity>(contact, new PartitionKey(contact.Id.ToString()));
        }

        public async Task<ContactEntity> GetContactAsync(Guid id)
        {
            ItemResponse<ContactEntity> response = await this._container.ReadItemAsync<ContactEntity>(id.ToString(), new PartitionKey(id.ToString()));
            return response.Resource;
        }

        public async Task UpdateContactAsync(Guid id, ContactEntity contact)
        {
            await this._container.UpsertItemAsync<ContactEntity>(contact, new PartitionKey(id.ToString()));
        }
    }
}