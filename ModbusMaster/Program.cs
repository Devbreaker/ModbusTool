using SciChart.Charting.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ModbusMaster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SciChartSurface.SetRuntimeLicenseKey("514HyY73jM1eSp0V07LXl4/7VIiKz2VDQNLCA9HXjt+IEXN04wq9WKSdJP5WG1pOqUVzdjSF4R+cfRtKLgTNCb2cLnhx23lJ7lpBh5g69kJotFDulp5e7IlhVx9kQ6BlYSMQR97NEbtU9tEBJU3Ob1fFKXQWAb7x+BaCCdc/v1Z+glpC5xBZgZxrk5bzer7g7PFkGDpyZ5Q3rKHqmD/wc3wYswB5f6tp5WMgxTbf12xv46N4qsdvelBe3VlN20jhS5pYVg6urXiFYZG3GCyAYHskeuahSkcviy+xYQDmyLchgLhxRF8Yoj7+qp9KU4jKwRoVkCf4HX0ZchHn3Im6byCY4mrAJh3tfWLVwztediJ1FStHKMKIQ8iUgyHCq4POGIM/rQEL/wS0e3HMCsJDivor83zEcZSviHZzIANOO1sgo0FbYVdolopiks+tTprMlqX9TkDkSey4RtCCCHknbndBOfEO0/lPlRfAfM4UU1bOrBjK0SK8PZ9IwKuqzpqrDVAxdGN317KnF+tpRrKrfbYBbunQnD4EbK1mobr5d7B5U+gaurPiDxeNuPfV1UIR4hCKO3G1rykyHl84j+ebyo5+nTo0PrNS/B/YJESbXlUQ96CfFGhJ3I6R2N54uUIHx7I6MtyI5X/WgCm2sDElKg9Uq/Sk+I0bzqRHtA==");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MasterForm());
        }
    }
}
