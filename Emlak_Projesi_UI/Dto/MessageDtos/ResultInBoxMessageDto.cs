﻿namespace Emlak_Projesi_UI.Dto.MessageDtos
{
    public class ResultInBoxMessageDto
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string UserImageUrl { get; set; }
    }
}
