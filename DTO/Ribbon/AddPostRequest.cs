namespace DTO.Users
{
    public class AddPostRequest
    {
        public int UserId { get; set; }
        public string? Text { get; set; }
        public string? imagesOne { get; set; }
        public string? imagesTwo { get; set; }
        public string? imagesThree { get; set; }
    }
}
