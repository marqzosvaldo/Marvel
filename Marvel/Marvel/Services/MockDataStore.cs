using Marvel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Services {
    public class MockDataStore : IDataStore<Itemm> {
        readonly List<Itemm> items;

        public MockDataStore() {
            items = new List<Itemm>()
            {
                new Itemm { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Itemm { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Itemm { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Itemm { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Itemm { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Itemm { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Itemm item) {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Itemm item) {
            var oldItem = items.Where((Itemm arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id) {
            var oldItem = items.Where((Itemm arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Itemm> GetItemAsync(string id) {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Itemm>> GetItemsAsync(bool forceRefresh = false) {
            return await Task.FromResult(items);
        }
    }
}