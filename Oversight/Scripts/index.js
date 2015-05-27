var chartData =  [
    {
        "date": "2012-01-01",
        "Story Points": 227,
        "idealstorypoints": 300

    },
    {
        "date": "2012-01-02",
        "Story Points": 371,
        "idealstorypoints": 300
    },
    {
        "date": "2012-01-03",
        "Story Points": 433,
        "idealstorypoints": 562
    },
    {
        "date": "2012-01-04",
        "Story Points": 345,
        "duration": 379
    },
    {
        "date": "2012-01-05",
        "Story Points": 0,
        "townName": "Miami",
        "townName2": "Miami",
        "townSize": 10,
        "latitude": 25.83,
        "duration": 501
    },
    {
        "date": "2012-01-06",
        "Story Points": 0,
        "townName": "Tallahassee",
        "townSize": 7,
        "latitude": 30.46,
        "duration": 443
    },
    {
        "date": "2012-01-07",
        "Story Points": 0,
        "townName": "New Orleans",
        "townSize": 10,
        "latitude": 29.94,
        "duration": 405
    },
    {
        "date": "2012-01-08",
        "Story Points": 0,
        "townName": "Houston",
        "townName2": "Houston",
        "townSize": 16,
        "latitude": 29.76,
        "duration": 309
    },
    {
        "date": "2012-01-09",
        "Story Points": 0,
        "townName": "Dalas",
        "townSize": 17,
        "latitude": 32.8,
        "duration": 287
    },
    {
        "date": "2012-01-10",
        "Story Points": 0,
        "townName": "Oklahoma City",
        "townSize": 11,
        "latitude": 35.49,
        "duration": 485
    },
    {
        "date": "2012-01-11",
        "Story Points": 0,
        "townName": "Kansas City",
        "townSize": 10,
        "latitude": 39.1,
        "duration": 600
    },
    {
        "date": "2012-01-12",
        "Story Points": 0,
        "townName": "Denver",
        "townName2": "Denver",
        "townSize": 18,
        "latitude": 39.74,
        "duration": 700
    },
    {
        "date": "2012-01-13",
        "townName": "Salt Lake City",
        "townSize": 12,
        "Story Points": 0,
        "duration": 670,
        "latitude": 40.75,
        "alpha": 0.4
    },
    {
        "date": "2012-01-14",
        "latitude": 36.1,
        "duration": 470,
        "townName": "Las Vegas",
        "townName2": "Las Vegas"
    },
    {
        "date": "2012-01-15"
    }
];
var chart = AmCharts.makeChart("chartdiv", {
    type: "serial",
    dataDateFormat: "YYYY-MM-DD",
    dataProvider: chartData,

    addClassNames: true,
    startDuration: 1,
    color: "#FFFFFF",
    marginLeft: 0,

    categoryField: "date",
    categoryAxis: {
        parseDates: true,
        minPeriod: "DD",
        autoGridCount: false,
        gridCount: 50,
        gridAlpha: 0.1,
        gridColor: "#FFFFFF",
        axisColor: "#555555",
        dateFormats: [{
            period: 'DD',
            format: 'DD'
        }, {
            period: 'WW',
            format: 'MMM DD'
        }, {
            period: 'MM',
            format: 'MMM'
        }, {
            period: 'YYYY',
            format: 'YYYY'
        }]
    },

    valueAxes: [{
        id: "a1",
        title: "Story Points",
        gridAlpha: 0,
        axisAlpha: 0
    }],
    graphs: [{
        id: "g1",
        valueField: "Story Points",
        title: "Story Points",
        type: "column",
        fillAlphas: 0.9,
        valueAxis: "a1",
        lineColor: "#27a9e0",
        alphaField: "alpha",
    }, {
        id: "g3",
        title: "idealstorypoints",
        valueField: "idealstorypoints",
        type: "line",
        valueAxis: "a3",
        lineColor: "#ff5755",
        lineThickness: 2,
        bulletBorderColor: "#ff5755",
        bulletBorderThickness: 1,
        bulletBorderAlpha: 1,
        dashLengthField: "dashLength",

    }],


});