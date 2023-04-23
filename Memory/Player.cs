namespace Memory
{
    public class Player
    {

        private string name;
        private string lastName;
        private string id;
        private string password;
        private string email;
        private float bestTime;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public float BestTime
        {
            get { return bestTime; }
            set { bestTime = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Player(string name, string lastName, string id, string password, string email)
        {
            this.name = name;
            this.lastName = lastName;
            this.id = id;
            this.password = password;
            this.email = email;
            this.bestTime = 0;
        }

        public override string ToString()
        {
            return name + "," + lastName + "," + id + "," + password + "," + email + "," + bestTime;
        }

    }
}
