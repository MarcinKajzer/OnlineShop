using Entities;
using Shop.DTOs;
using Shop.Entities;
using Shop.ViewModels;

namespace Shop.Helpers
{
    public class UserMapper
    {
        public User MapToUserModel(RegisterViewModel from)
        {
            return new User
            {
                Email = from.Email,
                UserName = from.Email,
                FirstName = from.FirstName,
                LastName = from.LastName
            };
        }

        public User UpdateExistingUser(UpdateUserViewModel from, User to)
        {
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;

            return to;
        }

        public UpdateUserViewModel MapToUpdateUserViewModel(User from)
        {
            UpdateUserViewModel viewModel = new UpdateUserViewModel
            {
                FirstName = from.FirstName,
                LastName = from.LastName,
                Id = from.Id
            };

            if (from.Adress != null)
                viewModel.Adress = MapAdress(from.Adress);

            return viewModel;
        }

        public Adress MapAdress(AdressDTO from)
        {
            return new Adress
            {
                City = from.City,
                PostCode = from.PostCode,
                BuildingNumber = from.BuildingNumber,
                FlatNumber = from.FlatNumber,
                Street = from.Street
            };
        }



        private AdressDTO MapAdress(Adress from)
        {
            return new AdressDTO
            {
                City = from.City,
                PostCode = from.PostCode,
                BuildingNumber = from.BuildingNumber,
                FlatNumber = from.FlatNumber,
                Street = from.Street
            };
        }
    }
}
