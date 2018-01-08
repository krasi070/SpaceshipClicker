// Unit values
let units = 0;
let unitsPerClick = 1;
let unitsPerSecond = 1;

// Crewmate values
let humanPrice = 100;
let magmarPrice = 1000;
let braniacPrice = 7500;
let icingPrice = 20000;
let increasePriceByPercent = 0.15;

// Crewmate U/s
let humanUnitsPerSecond = 1;
let magmarUnitsPerSecond = 5;
let braniacUnitsPerSecond = 50;
let icingUnitsPerSecond = 500;

// Upgrade values
let bathroomPrice = 2000;
let coffeePrice = 8000;
let enhancementsPrice = 20000;
let ai1Price = 50000;
let ai2Price = 100000;
let ai3Price = 200000;
let ai4Price = 500000;
let ai5Price = 1000000;

// NumberOfCrewmates
let numberOfHumans = 0;
let numberOfMagmars = 0;
let numberOfBraniacs = 0;
let numberOfIcings = 0;

// Unlock
let magmarUnlocked = false;
let braniacUnlocked = false;
let icingUnlocked = false;
let coffeeUnlocked = false;
let enhancementsUnlocked = false;
let ai1Unlocked = false;
let ai2Unlocked = false;
let ai3Unlocked = false;
let ai4Unlocked = false;
let ai5Unlocked = false;

function attachEvents() {
    $('li[name=notification-btn]').on('click', function () {
        $('div[gametab=gametab]').hide();
        $('#notifications-tab').show();
    });

    $('li[name=upgrades-btn]').on('click', function () {
        $('div[gametab=gametab]').hide();
        $('#upgrades-tab').show();
    });

    $('li[name=message-btn]').on('click', function () {
        $('div[gametab=gametab]').hide();
        $('#messages-tab').show();
    });

    $('#human-btn').on('click', function () {
        buyHuman();
    });

    setInterval(addUnitsPerSecond, 1000);
}

function addClickUnits() {
    units += unitsPerClick;
    $('#units').text(units);
    checkIfUpgradeUnlocks();
}

function addUnitsPerSecond() {
    units += unitsPerSecond;
    $('#units').text(units);
    checkIfUpgradeUnlocks();
}

function checkIfUpgradeUnlocks() {
    if (!magmarUnlocked && units >= magmarPrice) {
        $('#magmar-btn').attr('unlocked', 'unlocked');
        $('#magmar-btn .sc-crewmate-locked').hide();
        $('#magmar-btn .sc-crewmate-info').show();
        $('#magmar-btn img').show();
        $('#magmar-btn').on('click', function () {
            buyMagmar();
        });
    }

    if (!braniacUnlocked && units >= braniacPrice) {
        $('#braniac-btn').attr('unlocked', 'unlocked');
        $('#braniac-btn .sc-crewmate-locked').hide();
        $('#braniac-btn .sc-crewmate-info').show();
        $('#braniac-btn img').show();
        $('#braniac-btn').on('click', function () {
            buyBraniac();
        });
    }

    if (!icingUnlocked && units >= icingPrice) {
        $('#icing-btn').attr('unlocked', 'unlocked');
        $('#icing-btn .sc-crewmate-locked').hide();
        $('#icing-btn .sc-crewmate-info').show();
        $('#icing-btn img').show();
        $('#icing-btn').on('click', function () {
            buyIcing();
        });
    }
}

function buyHuman() {
    if (units >= humanPrice) {
        units -= humanPrice;
        $('#units').text(units);
        numberOfHumans++;
        $('#humanCount').text(numberOfHumans);
        unitsPerSecond += humanUnitsPerSecond;
        $('#unitsPerSecond').text(unitsPerSecond);
        humanPrice = Math.round(humanPrice * (1 + increasePriceByPercent));
        $('#humanPrice').text(humanPrice);
    }
}

function buyMagmar() {
    if (units >= magmarPrice) {
        units -= magmarPrice;
        $('#units').text(units);
        numberOfMagmars++;
        $('#magmarCount').text(numberOfMagmars);
        unitsPerSecond += magmarUnitsPerSecond;
        $('#unitsPerSecond').text(unitsPerSecond);
        magmarPrice = Math.round(magmarPrice * (1 + increasePriceByPercent));
        $('#magmarPrice').text(magmarPrice);
    }
}

function buyBraniac() {
    if (units >= braniacPrice) {
        units -= braniacPrice;
        $('#units').text(units);
        numberOfBraniacs++;
        $('#braniacCount').text(numberOfBraniacs);
        unitsPerSecond += braniacUnitsPerSecond;
        $('#unitsPerSecond').text(unitsPerSecond);
        braniacPrice = Math.round(braniacPrice * (1 + increasePriceByPercent));
        $('#braniacPrice').text(braniacPrice);
    }
}

function buyIcing() {
    if (units >= icingPrice) {
        units -= icingPrice;
        $('#units').text(units);
        numberOfIcings++;
        $('#icingCount').text(numberOfIcings);
        unitsPerSecond += icingUnitsPerSecond;
        $('#unitsPerSecond').text(unitsPerSecond);
        icingPrice = Math.round(icingPrice * (1 + increasePriceByPercent));
        $('#icingPrice').text(icingPrice);
    }
}

function buyBathroom() {

}