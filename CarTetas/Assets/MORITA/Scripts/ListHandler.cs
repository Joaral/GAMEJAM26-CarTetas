
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListHandler : MonoBehaviour
{
    public List<string> textsBonitos = new List<string>
    {
        "I love you like squirrels love nuts.",
        "You are the reason I wake up every morning (I love you but please stop snoring).",
        "I’m so in love with you I sometimes compare myself to Yandere Simulator’s character.",
        "Love you even when you steal my blanket.",
        "I’ll kill you... with lots of kisses!",
        "I love you more than sleeping in on a rainy day.",
        "You make my brain stop working, and honestly I’m grateful.",
        "I’d share my fries with you, even the crispy ones.",
        "You’re my favorite notification.",
        "I love you more than cancelling plans.",
        "You feel like home, but with snacks.",
        "I’d still choose you in a room full of puppies.",
        "You’re the reason my playlist makes sense.",
        "I love you even when you steal my hoodie and deny it.",
        "If I had one brain cell left, I’d use it to think of you.",
        "You’re cuter than my search history is embarrassing.",
        "I’d pause my game for you. That’s serious love.",
        "You’re my emotional support human.",
        "I love you in a “I saved you the last cookie” way.",
        "You make Mondays survivable.",
        "I’d watch the same movie again just because you like it.",
        "You’re my favorite side quest.",
        "I love you louder than your alarm clock.",
        "You’re the good part of my day.",
        "I’d lend you my headphones.",
        "You’re my favorite distraction.",
        "I love you more than free Wi-Fi.",
        "You’re the reason I check my phone smiling.",
        "I’d fight a goose for you.",
        "Loving you feels illegal in at least five countries."
    };

    public List<string> textsFeitos = new List<string>
    {
        "My grandmother is watching through your window.",
        "I’ll stab your cutest plushie.",
        "I’ll reveal to everyone you use unicorn socks.",
        "We know you like that furry stuff.",
        "I’ll kill you with violence.",
        "I prayed to Satan for you to become bald.",
        "I’ll send your mom your browser history.",
        "I hope you choke eating an asparragus.",
        "Tomorrow Donald Trump will be waiting at your door, he’s desperate to kiss you...",
        "I hope water splashes back on your cute ass when you poop. And I hope the water is cold.",
        "I hope the next time you go to sleep the two sides of the pillow are hot.",
        "I hope you play League of Legends for the rest of your days.",
        "I wish you eternal lag and bad wifi signal going.",
        "I’ll be your step-daddy.",
        "You are worse than writing “uwu”.",
        "You are worse than paying Youtube Premium.",
        "You will die alone, only worms will love you.",
        "Even McDonalds won’t hire you.",
        "You stink, I’ll make you drink a whole bottle of deodorant.",
        "I’ll replace your shampoo with dish soap.",
        "I hope your phone charger only works at a specific angle.",
        "I’ll hide all your left socks and deny everything.",
        "I hope autocorrect betrays you in front of your boss.",
        "I’ll slightly loosen every jar so you never feel accomplished.",
        "I hope your alarm rings on weekends only.",
        "I’ll microwave your ice cream for exactly 7 seconds.",
        "I hope your favorite series gets cancelled on a cliffhanger.",
        "I’ll change your language settings to something unpronounceable.",
        "I hope your coffee tastes like disappointment forever.",
        "I’ll sign you up for newsletters you can never unsubscribe from."
    };

    public List<string> textsTrabajo = new List<string>
    {
        "We are sorry, we have already hired someone for the position of Santa Claus.",
        "I want to apply for your job advertisement, specifically the one for handling elderly women’s feet.",
        "Don’t worry, cleaning 6m long alligator’s teeth doesn’t scare me at all. Of course I accept!",
        "Such an exotic job! Never heard of waxing cactus! I’m in for a new experience!",
        "Security guard? From 12pm to 6am? I don’t know... Sounds scary, but I might join the party.",
        "I’m sorry, but who the f*ck invented a job like Winrar tester?",
        "If you assure me I’ll have good health insurance, I'll rethink working as poison tester.",
        "S- sorry, but... can I keep my cl- clothes on while posing? I- I- get shy with people looking at my naked b- body...",
        "You pay me too much just to steal 3 dachshunds, I'll make you a deal: 3 for the price of 2.",
        "Just wanted to let you know that the last suit was too hot, I almost pass out. Also, be careful with the furrys that surround you...",
        "Famous hairstylist known for styling Vin Diesel, The Rock and Mr. Worldwide.",
        "Yes, I have experience pretending to work while my soul leaves my body.",
        "Night shift? Perfect, I don’t believe in sleep anyway.",
        "I can start immediately, my dignity resigned years ago.",
        "Unpaid internship? Amazing, I love character development arcs.",
        "I’ve worked under pressure, mostly financial.",
        "Sorry for my résumé, it’s mostly trauma and bad decisions.",
        "I’m fluent in Excel, Word, and quiet despair.",
        "Is this job remote or just emotionally distant?",
        "I’m overqualified but underpaid, a classic combo.",
        "I can lift heavy boxes and heavier regrets.",
        "Flexible schedule? My life is already a mess, so yes.",
        "I work well alone, mostly because nobody answers my emails.",
        "Do you offer coffee or just existential dread?",
        "I’m willing to learn, unlearn, and cry in the bathroom.",
        "My biggest weakness is hope.",
        "I can start Monday or immediately after my breakdown.",
        "I have references, but they’ve stopped believing in me.",
        "I thought this was a pyramid scheme, but I’m still interested.",
        "I don’t need weekends, I need money."
    };

    public void SetTextByCard(GameObject card)
    {
        if (card == null) return;

        TextMeshProUGUI tmp = card.GetComponentInChildren<TextMeshProUGUI>();

        if (tmp == null)
        {
            Debug.LogWarning("La carta no tiene TextMeshProUGUI");
            return;
        }

        List<string> lista = null;

        switch (card.tag)
        {
            case "Love":
                lista = textsBonitos;
                break;
            case "Dead":
                lista = textsFeitos;
                break;
            case "Job":
                lista = textsTrabajo;
                break;
        }

        if (lista == null || lista.Count == 0) return;

        tmp.text = lista[Random.Range(0, lista.Count)];
    }
}




