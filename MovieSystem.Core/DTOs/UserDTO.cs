namespace MovieSystem.Core.DTOs
{
    namespace MovieSystem.Core.DTOs
    {
        public class UserDto
        {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public class CreateUserDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }

}
