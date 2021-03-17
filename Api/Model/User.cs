using System;

namespace Api.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}