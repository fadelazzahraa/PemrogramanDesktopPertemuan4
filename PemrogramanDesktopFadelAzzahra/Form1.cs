using Google.Protobuf.WellKnownTypes;
using OpenAI_API.Chat;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static readonly OpenAIAPI api = new("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");
        Conversation chat = api.Chat.CreateConversation();

        private void button1_Click(object sender, EventArgs e)
        {
            //Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                Diameter = 391F,
                Weight = 8805F,
                Red = 166F,
                Green = 78F,
                Blue = 3F,
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);
            MessageBox.Show(result.PredictedLabel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Load sample data
            var sampleData = new MLModel3.ModelInput()
            {
                Comment = @"Geblek lo tata...cowo bgt dibela2in balikan...hadeww...ntar ditinggal lg nyalahin tuh cowo...padahal kitenya yg oon.",
            };

            //Load model and predict output
            var result = MLModel3.Predict(sampleData);
            MessageBox.Show(result.PredictedLabel);

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            chat.AppendUserInput(textBox1.Text);
            string response = await chat.GetResponseFromChatbotAsync();
            richTextBox1.Text = response;
        }
        

        private async void Form1_Load(object sender, EventArgs e)
        {
            chat.AppendSystemMessage("You are OrderBot, an automated service to collect orders for a pizza restaurant.You first greet the customer, then collects the order, and then asks if it's a pickup or delivery. You wait to collect the entire order, then summarize it and check for a final time if the customer wants to add anything else. If it's a delivery, you ask for an address. Finally you collect the payment.Make sure to clarify all options, extras and sizes to uniquely identify the item from the menu.You respond in a short, very conversational friendly style.The menu includes:" +
           " pepperoni pizza  12.95, 10.00, 7.00 " +
           " cheese pizza   10.95, 9.25, 6.50 " +
           " eggplant pizza   11.95, 9.75, 6.75 " +
           " fries 4.50, 3.50 " +
           " greek salad 7.25 " +
           " Toppings: " +
           " extra cheese 2.00, " +
           " mushrooms 1.50 " +
           " sausage 3.00 " +
           " canadian bacon 3.50 " +
           " AI sauce 1.50 " +
           " peppers 1.00 " +
           " Drinks: " +
           " coke 3.00, 2.00, 1.00 " +
           " sprite 3.00, 2.00, 1.00 " +
           " bottled water 5.00 ");
            chat.AppendUserInput("Hello!");
            string response = await chat.GetResponseFromChatbotAsync();
            richTextBox1.Text = response;
        }
    }
}
