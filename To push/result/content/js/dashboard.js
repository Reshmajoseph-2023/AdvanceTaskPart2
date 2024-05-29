/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 89.47368421052632, "KoPercent": 10.526315789473685};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.8681578947368421, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [1.0, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [1.0, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [1.0, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.5, 500, 1500, "Search Skills by Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Edit Profile Description "], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications"], "isController": false}, {"data": [0.995, 500, 1500, "Sign  In"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.0, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.0, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Sign Out"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 1900, 200, 10.526315789473685, 130.64736842105262, 1, 1279, 57.0, 184.0, 968.9499999999998, 1009.99, 18.728806876429303, 11.23863179904976, 12.100180018334518], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["ViewShareSkill", 100, 0, 0.0, 2.4600000000000004, 1, 6, 2.0, 3.9000000000000057, 4.0, 5.989999999999995, 1.0262620457507619, 0.17638878911341221, 0.5882967000543918], "isController": false}, {"data": ["Update Skills", 100, 0, 0.0, 171.63, 156, 473, 166.5, 174.0, 179.89999999999998, 472.2999999999996, 1.0180085716321732, 0.20578884211705065, 0.6561383371847991], "isController": false}, {"data": ["AddShareSkill", 100, 0, 0.0, 86.55000000000001, 77, 151, 84.5, 92.0, 95.94999999999999, 150.54999999999978, 1.0254201659129827, 0.224310661293465, 1.6873368941048594], "isController": false}, {"data": ["Add Education", 100, 0, 0.0, 121.80000000000004, 106, 165, 117.0, 150.9, 154.89999999999998, 165.0, 1.02183664919326, 0.20656268201465314, 0.7214725560221943], "isController": false}, {"data": ["DeleteShareSkill", 100, 0, 0.0, 171.32999999999996, 150, 197, 170.5, 181.8, 183.0, 196.92999999999995, 1.0243802499487809, 0.19007055418971522, 0.5912194606637984], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 48.23, 40, 228, 44.0, 48.900000000000006, 54.0, 228.0, 1.022892330353307, 0.217764187516622, 0.5953553016509482], "isController": false}, {"data": ["Disable/Enable", 100, 0, 0.0, 126.23, 110, 148, 126.0, 134.0, 136.95, 147.93999999999997, 1.025010250102501, 0.19018744874948748, 0.5815731985444854], "isController": false}, {"data": ["Delete Skills", 100, 0, 0.0, 44.640000000000015, 40, 56, 44.5, 48.900000000000006, 49.94999999999999, 55.989999999999995, 1.0224635236137951, 0.19171191067758658, 0.6590096929542039], "isController": false}, {"data": ["Search Skills by Categories", 100, 0, 0.0, 1003.7800000000002, 959, 1279, 989.0, 1021.6, 1109.7499999999995, 1278.87, 1.013695019716368, 5.9406091926932865, 0.7375027243053655], "isController": false}, {"data": ["Update Education", 100, 0, 0.0, 185.99000000000007, 151, 211, 188.0, 197.9, 199.95, 210.96999999999997, 1.0213669975895738, 0.22242660201413572, 0.7301178146831719], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 50.970000000000006, 42, 324, 46.0, 52.0, 53.0, 322.8899999999994, 1.0156821321199316, 0.24003425387990573, 0.6407525950678475], "isController": false}, {"data": ["Edit Profile Description ", 100, 0, 0.0, 130.51999999999987, 118, 364, 127.0, 135.0, 140.0, 361.999999999999, 1.0239187418086502, 0.21998254218545216, 0.6019522290711009], "isController": false}, {"data": ["Add Certifications", 100, 0, 0.0, 56.800000000000004, 51, 83, 56.0, 60.0, 62.94999999999999, 82.88999999999994, 1.0224426154082102, 0.22266084300393638, 0.7039277772097541], "isController": false}, {"data": ["Sign  In", 100, 0, 0.0, 169.29000000000005, 144, 631, 162.5, 184.0, 199.5499999999999, 626.8299999999979, 1.0096115014942249, 0.48508677610855344, 0.3500117998344237], "isController": false}, {"data": ["Add Skills", 100, 0, 0.0, 45.65999999999998, 41, 78, 45.0, 49.0, 50.0, 77.73999999999987, 1.0189109879360938, 0.2059712641628627, 0.637814397721715], "isController": false}, {"data": ["Delete Language", 100, 100, 100.0, 7.2500000000000036, 3, 42, 7.0, 10.0, 11.0, 41.69999999999985, 1.018962899560827, 0.11045398618286309, 0.57515679291617], "isController": false}, {"data": ["Delete Certifications", 100, 100, 100.0, 7.750000000000001, 3, 30, 7.0, 11.0, 13.0, 29.909999999999954, 1.0229341844145747, 0.11088446725587676, 0.5823931928844699], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 46.650000000000006, 41, 59, 46.0, 52.80000000000001, 54.0, 58.97999999999999, 1.018547754611475, 0.21882861915480906, 0.6246562401328186], "isController": false}, {"data": ["Sign Out", 100, 0, 0.0, 4.77, 2, 28, 4.5, 6.0, 7.0, 27.819999999999908, 1.0259146028684571, 2.024778723044094, 0.27250856638693394], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 200, 100.0, 10.526315789473685], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 1900, 200, "500/Internal Server Error", 200, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Language", 100, 100, "500/Internal Server Error", 100, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Certifications", 100, 100, "500/Internal Server Error", 100, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
