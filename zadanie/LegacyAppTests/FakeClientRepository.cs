using LegacyApp;

namespace LegacyAppTests;

public class FakeClientRepository : IClientRepository

{
 private Dictionary<int, Client?> _clients = new Dictionary<int, Client?>();

 public FakeClientRepository()
 {
  
  _clients.Add(1, new Client { ClientId = 1, Name = "Mike Nowak", Email = "test1@example.com", Type = "NormalClient" });
  _clients.Add(2, new Client { ClientId = 2, Name = "Stan Kowalski", Email = "test2@example.com", Type = "ImportantClient" });
  _clients.Add(3, new Client { ClientId = 3, Name = "James Jones", Email = "test3@example.com", Type = "VeryImportantClient" });
  _clients.Add(4, new Client { ClientId = 4, Name = "Roch Reiss", Email = "test4@example.com", Type = "ImportantClient" });
 }
 public IEnumerable<Client?> GetAllClients()
 {
  return _clients.Values;
 }
 public Client? GetById(int clientId)
 {
  if (_clients.ContainsKey(clientId))
  {
   return _clients[clientId];
  }
  return null; 
 }
 
 public void AddClient(Client? client)
 {
  if (client != null) _clients[client.ClientId] = client;
 }
 public void DisplayAllClients(FakeClientRepository fakeClientRepository)
 {
  var clients = fakeClientRepository.GetAllClients();
  Console.WriteLine("Lista klientów:");
  foreach (var client in clients)
  {
   if (client != null)
    Console.WriteLine($"ID: {client.ClientId}, Nazwa: {client.Name}, Email: {client.Email}, Typ: {client.Type}");
  }
 }
 
 public void Clear()
 {
  _clients.Clear();
 }
}
