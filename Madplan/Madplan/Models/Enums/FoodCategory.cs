using System.ComponentModel;

namespace Madplan.Models.Enums
{
    public enum FoodCategory
    {
        [Description("Alle")]
        Alle,

        // Hovedingredienser
        [Description("Pasta")]
        Pasta,

        [Description("Kylling")]
        Kylling,

        [Description("Oksekød")]
        Oksekød,

        [Description("Svinekød")]
        Svinekød,

        [Description("Fisk & skaldyr")]
        FiskOgSkaldyr,

        // Kosttyper
        [Description("Vegetarisk")]
        Vegetarisk,

        [Description("Vegansk")]
        Vegansk,

        [Description("Sund & let")]
        SundOgLet,

        // Rettyper
        [Description("Supper & gryderetter")]
        SupperOgGryderetter,

        [Description("Salater")]
        Salater,

        [Description("Wraps & sandwiches")]
        WrapsOgSandwiches,

        [Description("Tilbehør")]
        Tilbehoer,

        // Klassikere & tema
        [Description("Klassisk dansk")]
        KlassiskDansk,

        // Sødt
        [Description("Dessert")]
        Dessert,

        [Description("Kager & bagværk")]
        KagerOgBagvaerk,

        [Description("Snacks")]
        Snacks
    }
}
