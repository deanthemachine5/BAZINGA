String.prototype.addCommas = function () {     
    return parseInt(this).toLocaleString(
        'en-US',
        { minimumFractionDigits: 0 }
        );  
};

var CngCalculator = kendo.observable({
    onChange: function (e) {
        this.set(e.sender.element[0].id + ".Value", e.value);
    },
    
    FleetSize: {
        Value: $Dean.Config.DefaultFleetSize,
        Formatted: function () {
            return this.get("Value").toFixed(0).addCommas();
        }
    },
    AvgMilesPerYear: {
        Value: $Dean.Config.DefaultAvgMilesPerYear,
        Formatted: function () {
            return this.get("Value").toFixed(0).addCommas();
        }
    },
    AvgDieselMPG: {
        Value: $Dean.Config.DefaultAvgDieselMPG,
        Formatted: function () {
            return this.get("Value").toFixed(1);
        }
    },
    DieselCost: {
        Value: $Dean.Config.DefaultDieselCost,
        Formatted: function () {
            return this.get("Value").toFixed(2);
        }
    },
    NaturalGasCost: {
        Value: $Dean.Config.DefaultNaturalGasCost,
        Formatted: function () {
            return this.get("Value").toFixed(2);
        }
    },
    IncrementalNGTruckCost: {
        Value: $Dean.Config.DefaultIncrementalNGTruckCost,
        Formatted: function () {
            return this.get("Value").toFixed(0).addCommas();
        }
    },
    GovernmentIncentives: {
        Value: $Dean.Config.DefaultGovernmentIncentives,
        Formatted: function () {
            return this.get("Value").toFixed(0).addCommas();
        }
    },
    
    NaturalGasGallonEquivalentsUsed: {
        Value: function () {           
            return (CngCalculator.get("FleetSize.Value") * CngCalculator.get("AvgMilesPerYear.Value")) / 5.5
        },
        Formatted: function () {            
            return ( CngCalculator.get("NaturalGasGallonEquivalentsUsed.Value()").toFixed(0).addCommas());
        }        
    },
    DieselGallonsUsed: {
        Value: function () {           
            return (parseFloat((CngCalculator.get("FleetSize.Value") * CngCalculator.get("AvgMilesPerYear.Value")) / CngCalculator.get("AvgDieselMPG.Value")));
        },
        Formatted: function () {
            
            return CngCalculator.get("DieselGallonsUsed.Value()").toFixed(0).addCommas();
        }
    },
    NaturalGasAnnualFuelCost: {
        Value: function () {           
            return (parseFloat(CngCalculator.get("NaturalGasGallonEquivalentsUsed.Value()") * CngCalculator.get("NaturalGasCost.Value")));
        },
        Formatted: function () {            
            return CngCalculator.get("NaturalGasAnnualFuelCost.Value()").toFixed(0).addCommas();
        }        
    },
    DieselAnnualFuelCost: {
        Value: function () {           
            return (parseFloat(CngCalculator.get("DieselCost.Value") * CngCalculator.get("DieselGallonsUsed.Value()")));
        },
        Formatted: function () {            
            return CngCalculator.get("DieselAnnualFuelCost.Value()").toFixed(0).addCommas();
        } 
    },
    AnnualFuelSavings: {
        Value: function(){
            return parseFloat(CngCalculator.get("DieselAnnualFuelCost.Value()") - CngCalculator.get("NaturalGasAnnualFuelCost.Value()"));
        },

        Formatted: function() {
            var savings = CngCalculator.get("AnnualFuelSavings.Value()")
            var savingsDiv = $("#DivAnnualFuelSavings");
            if (savings < 0) {
                savingsDiv.addClass('redText');
                savingsDiv.removeClass('greenText');
            }
            else {
                savingsDiv.addClass('greenText');
                savingsDiv.removeClass('redText');
            }

            return savings.toFixed(0).addCommas();
        }
    },
    PaybackNaturalGasTruck: function () {          
        var number = ((CngCalculator.get("FleetSize.Value") * (CngCalculator.get("IncrementalNGTruckCost.Value") - CngCalculator.get("GovernmentIncentives.Value"))) / CngCalculator.get("AnnualFuelSavings.Value()"));
        var payBackDiv = $("#DivPayback");
        number = isFinite(number) ? number : 0; 
        if (number < 0) {
            payBackDiv.addClass('redText');
            payBackDiv.removeClass('greenText');
        }
        else {
            payBackDiv.addClass('greenText');
            payBackDiv.removeClass('redText');
        }

        return number.toFixed(2);
    },
});

$(function () {
    kendo.bind($("#wrapper"), CngCalculator);    
});

