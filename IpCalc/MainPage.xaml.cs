

namespace IpCalc
{
    public partial class MainPage : ContentPage
    {


        int SHORT_MASK  = 0;
        int[] NETWORK_ADD = { 0, 0, 0, 0 };
        int[] BROAD_ADD = {0, 0, 0, 0 };

        public MainPage()
        {
            InitializeComponent();
        }


        private void IPcalculation(object sender, EventArgs e)
        {

            IP.Text = "IP Address: ";
            BIN_IP.Text = "In Binary: ";
            MASK.Text = "Mask: ";
            BIN_MASK.Text = "In Binary: ";
            SHORT_MASKA.Text = "Short MASK: ";
            TYPE.Text = "Network Type: ";
            HOSTAMOUNT.Text = "Host amount: ";
            AVHOSTAMOUNT.Text = "Available Host amount: ";
            NETWORK_ADDRESS.Text = "Network address: ";
            BROADCAST_ADRESS.Text = "Broadcast address: ";
            SUBNET_AMOUNT.Text = "Subnets: ";


            if (IP_Input.Text == null || MASK_Input.Text == null)
            {
                text_holder.Text = "Nie podano argumentów";
            }
            else {
                string[] IPADDRESS_string = (IP_Input.Text).Split('.');
                int[] IPADDRESS_int = { 0, 0, 0, 0 };
                int[] IPADDRESS_bin = { 0, 0, 0, 0 };
                ONE_STEP(IPADDRESS_string, IPADDRESS_int, IPADDRESS_bin);

                string[] MASK_string = (MASK_Input.Text).Split(".");
                int[] MASK_int = { 0, 0, 0, 0 };
                int[] MASK_bin = { 0, 0, 0, 0 };
                ONE_STEP(MASK_string, MASK_int, MASK_bin);

                for (int i = 0; i < MASK_string.Length; i++)
                {
                    SHORT_MASK += MASK_string[i].Count(f => f == '1');
                }

                NETADDRESS(IPADDRESS_int, NETWORK_ADD, BROAD_ADD, MASK_CLASS(SHORT_MASK));

                IP.Text += RETURNER(IPADDRESS_int);
                BIN_IP.Text += RETURNER(IPADDRESS_bin);
                MASK.Text += RETURNER(MASK_int);
                BIN_MASK.Text += RETURNER(MASK_bin);
                SHORT_MASKA.Text += $"{SHORT_MASK}";
                TYPE.Text += MASK_CLASS(SHORT_MASK);
                HOSTAMOUNT.Text += HOSTS(SHORT_MASK);
                AVHOSTAMOUNT.Text += HOSTS(SHORT_MASK) - 2;
                NETWORK_ADDRESS.Text += RETURNER(NETWORK_ADD);
                BROADCAST_ADRESS.Text += RETURNER(BROAD_ADD);
                //SUBNET_AMOUNT.Text += subnetAmount(SHORT_MASK, MASK_CLASS(SHORT_MASK));
            }
        }

        private void ONE_STEP(string[] STRING_VER, int[] INT_VER, int[] BIN_VER)
        {
            for (int i = 0;i < STRING_VER.Length;i++)
            {
                int toBASE = 2;
                INT_VER[i] = int.Parse(STRING_VER[i]);
                STRING_VER[i] = (Convert.ToString(INT_VER[i], toBASE));
                BIN_VER[i] = int.Parse(STRING_VER[i]);
            }
        
        }
    
        private string RETURNER(int[] ARRAY_VER)
        {
            string return_text = "";
            for (int i = 0;  i < ARRAY_VER.Length;i++)
            {
                return_text += $"{ARRAY_VER[i]}";
                if (i != ARRAY_VER.Length - 1)
                {
                    return_text += ".";
                }
            }
            return return_text;
        }
       
        private double HOSTS(int shortmask)
        {
            return Math.Pow(32-shortmask, 2);
        }

        private void NETADDRESS(int[] IP_ADDRESS, int[] NET_ADDRESS, int[] BROAD_ADDRESS, string CASE)
        {
            if (CASE == "c")
            {
                for (int i = 0; i < IP_ADDRESS.Length - 1; i++) 
                {
                    
                    NET_ADDRESS[i] = IP_ADDRESS[i];
                    BROAD_ADDRESS[i] = IP_ADDRESS[i];
                    
                }
                NET_ADDRESS[3] = 0;
                BROAD_ADDRESS[3] = 255;
            }
            else if (CASE == "b") 
            {
                for (int i = 0; i < IP_ADDRESS.Length - 2; i++)
                {
                    NET_ADDRESS[i] = IP_ADDRESS[i];
                    BROAD_ADDRESS[i] = IP_ADDRESS[i];
                }
                for (int i = 2; i < IP_ADDRESS.Length; i++)
                {
                    NET_ADDRESS[i] = 0;
                    BROAD_ADDRESS[i] = 255;
                }
            }
            else if (CASE == "a")
            {
                for (int i = 4; i > IP_ADDRESS.Length; i--)
                {
                    NET_ADDRESS[i] = 0;
                    BROAD_ADDRESS[i] = 0;
                }
                NET_ADDRESS[0] = IP_ADDRESS[0];
                BROAD_ADDRESS[0] = IP_ADDRESS[0];
            }
        }
        
        
        /*private int subnetAmount(int mask, string CASE)
        {
            double divider;
            if (CASE == "c")
            {
                mask =- 32;
            }  
            else if (CASE == "b")
            {
                mask =- 24; 
            }
            else
            {
                mask =- 8; 
            }
            
            int i = -1;
            while (i < )
        }*/   
        
        /*private void SUBNET(int[] IP_ADRES, int mask, int[] NETADDRESS, int[] BROADADRESS)
        {
            int[] First_ADDRESS = new int[4];
            int[] LAST_ADDRESS = new int[4];

            for (int i = 0; i < IP_ADRES.Length; i++) 
            {
                First_ADDRESS[i] = NETADDRESS[i];
                LAST_ADDRESS[i] = BROADADRESS[i];
            }
            


        }*/
        
        
        
        private string MASK_CLASS(int MASKA)
        {
            string Type = "";
            switch (MASKA)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    Type = "a";
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    Type = "b";
                    break;
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    Type = "c";
                    break;
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                    Type = "d";
                    break;
            }
            return Type;
        }    
    }

}
