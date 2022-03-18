using ContactAppBackend.Dto;
using ContactAppBackend.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppBackend.Services
{
    public class ContactService
    {
        private readonly AppContext appContext;

        public ContactService()
        {
            this.appContext = new AppContext();
        }
        public ActionResult<APIResult> CrateContact(CreateContactDto dto)
        {   
            var result = new APIResult(); 
            Contact contact = CreateContactFromItsCreateRequest(dto);

            // set Contact.Owner state UNCHANGED 
            this.appContext.Entry(contact.Owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            this.appContext.Contacts.Add(contact);
            result.Success = true;
            result.Description = "Contact yaratıldı";
            this.appContext.SaveChanges();
            return result;
        }

        public ActionResult<APIResult> DeleteContact(int id)
        {
            var result = new APIResult();
            Contact? contact = appContext.Contacts.Find(id);
            if (contact == null)
            {
                result.Description = "Girilen id ile contact yok";
                result.Success = false;
                return result;
            }
            
            // contacts/2 DELETE
            appContext.Contacts.Remove(contact);
            appContext.SaveChanges();
            result.Success = true;
            result.Description = "Silindi";

            return result;
        }


        public ActionResult<IEnumerable<ContactDto>> GetContact()
        {
            var result = new List<ContactDto>();
            var contacts = appContext.Contacts.ToList();
            foreach (var contact in contacts)
            {
                var user = appContext.Users.Find(contact.OwnerId);
                result.Add(new ContactDto()
                {
                    Id = contact.Id,
                    PhoneNumber = contact.PhoneNumber,
                    Adress = contact.Adress,
                    Title = contact.Title,
                    District = contact.District,
                    Province = contact.Province,
                    OwnerName = user.Name + ' ' + user.Surname,

                });
            }
            return result;
        }

       
        public ActionResult<Contact> GetContactsById(int id)
        {
            var contact = this.appContext.Contacts.Find(id);
            return contact;
        }

        public ActionResult<IEnumerable<ContactDto>> GetContactsByOwnerId(int ownerId)
        {
            var result = new List<ContactDto>();
            var contacts = appContext.Contacts.Where(e => e.OwnerId == ownerId).ToList();
            if (contacts == null) { return new List<ContactDto>(); }

            foreach (var item in contacts)
            {
                var user = appContext.Users.Find(item.OwnerId);
                var dto = new ContactDto()
                {
                    Id =item.Id,
                    Title = item.Title,
                    PhoneNumber = item.PhoneNumber,
                    Adress = item.Adress,
                    Province = item.Province,
                    District = item.District,
                    OwnerName = $"{user.Name} {user.Surname}"
                };
                result.Add(dto);    
            }

            return result;
           
        }

        private static Contact CreateContactFromItsCreateRequest(CreateContactDto dto)
        {
            return new Contact()
            {
                Title = dto.Title,
                PhoneNumber = dto.PhoneNumber,
                Province = dto.Province,
                Adress = dto.Adress,
                District = dto.District,
                OwnerId = dto.OwnerId,
                Owner = new User()
                {
                   Id = dto.OwnerId
                }
            };
        }


    }
}
