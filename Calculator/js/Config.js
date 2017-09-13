$Dean = typeof ($Dean) == 'undefined' ? {} : $Dean;
(function ($) {
    $Dean.Config = $Dean.Config || {
        DefaultFleetSize: 50,
        DefaultAvgMilesPerYear: 125000,
        DefaultAvgDieselMPG: 6.5,
        DefaultDieselCost: 3.75,
        DefaultNaturalGasCost: 2.00,
        DefaultIncrementalNGTruckCost: 60000,
        DefaultGovernmentIncentives: 0,

        InitializeKendoSliders: function () {

            $("#FleetSize").kendoSlider({
                max: 200,
                min: 1,
                smallStep: 1,
                tooltip: {
                    enabled: false
                },
                showButtons: false
            });

            $("#AvgMilesPerYear").kendoSlider({
                max: 250000,
                min: 5000,
                tooltip: {
                    enabled: false
                },
                smallStep: 5000,
                showButtons: false
            });

            $("#AvgDieselMPG").kendoSlider({
                max: 10,
                min: 1,
                tooltip: {
                    enabled: false
                },
                smallStep: .1,
                showButtons: false
            });

            $("#DieselCost").kendoSlider({
                max: 8,
                min: 3,
                smallStep: .05,
                tooltip: {
                    enabled: false
                },
                showButtons: false
            });

            $("#NaturalGasCost").kendoSlider({
                max: 8,
                min: 1,
                smallStep: .05,
                tooltip: {
                    enabled: false
                },
                showButtons: false
            });

            $("#IncrementalNGTruckCost").kendoSlider({
                max: 100000,
                min: 0,
                smallStep: 1000,
                tooltip: {
                    enabled: false
                },
                showButtons: false
            });

            $("#GovernmentIncentives").kendoSlider({
                max: 100000,
                min: 0,
                tooltip: {
                    enabled: false
                },
                smallStep: 1000,
                showButtons: false
            });
        }
        
    }  



})(jQuery);