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

    var data = {"OkPercent": 98.63952865559722, "KoPercent": 1.3604713444027852};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.80037493304767, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.2917647058823529, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Add Education"], "isController": false}, {"data": [0.31467661691542287, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.3412887828162291, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.04972972972972973, 500, 1500, "Search Skills by Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [0.9989247311827957, 500, 1500, "Edit Profile Description "], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications"], "isController": false}, {"data": [0.9917355371900827, 500, 1500, "Sign  In"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.9288888888888889, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.7879464285714286, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Sign Out"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 9335, 127, 1.3604713444027852, 1532.5016604177843, 1, 176496, 52.0, 3883.7999999999993, 6890.799999999996, 13171.919999999984, 41.920012933008806, 35.81210535097626, 27.55885722356816], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["ViewShareSkill", 419, 0, 0.0, 7.761336515513127, 1, 63, 6.0, 17.0, 18.0, 21.0, 1.9938803576612119, 0.34269818647302075, 1.1429763378389954], "isController": false}, {"data": ["Update Skills", 450, 0, 0.0, 142.05333333333343, 38, 431, 162.0, 182.0, 192.89999999999998, 281.33000000000015, 2.079520878389619, 0.4468307307551896, 1.3328429129928465], "isController": false}, {"data": ["AddShareSkill", 425, 0, 0.0, 5289.218823529413, 71, 39337, 2914.0, 12030.400000000005, 13366.1, 38268.18, 1.9813242705230227, 0.4334146841769113, 3.260284566241498], "isController": false}, {"data": ["Add Education", 448, 0, 0.0, 45.86607142857142, 37, 137, 45.0, 51.0, 54.0, 74.01999999999998, 2.0901469168000224, 0.4551784789515674, 1.4757580281703284], "isController": false}, {"data": ["DeleteShareSkill", 402, 0, 0.0, 5687.853233830846, 146, 162397, 2193.0, 10236.9, 12509.799999999992, 111794.37999999881, 1.874798878851616, 0.3478630732244209, 1.0820372435559618], "isController": false}, {"data": ["Delete Education", 447, 0, 0.0, 3.651006711409395, 1, 64, 3.0, 6.0, 7.0, 15.519999999999982, 2.086006953356511, 0.44816555638518796, 1.4585751744172482], "isController": false}, {"data": ["Disable/Enable", 419, 0, 0.0, 7415.906921241047, 109, 165062, 2097.0, 12152.0, 13437.0, 159594.80000000016, 1.9534437021254771, 0.36245537441781317, 1.1083503817723657], "isController": false}, {"data": ["Delete Skills", 450, 0, 0.0, 35.77111111111108, 1, 164, 42.0, 49.0, 51.0, 64.94000000000005, 2.0813675972692454, 0.41960695974635065, 1.3340265443747572], "isController": false}, {"data": ["Search Skills by Categories", 925, 0, 0.0, 6674.911351351345, 1024, 176496, 3655.0, 7101.4, 8078.2999999999965, 117294.94, 4.161511640985267, 24.387921247609942, 3.027662277865257], "isController": false}, {"data": ["Update Education", 447, 0, 0.0, 2.37807606263982, 1, 23, 2.0, 4.0, 4.0, 5.519999999999982, 2.0858998768059136, 0.452216574854407, 1.148874541522007], "isController": false}, {"data": ["Add Language", 454, 0, 0.0, 49.97356828193831, 38, 407, 47.0, 57.0, 60.0, 121.99999999999955, 2.0956812348824756, 0.42868747865082446, 1.4223617756282427], "isController": false}, {"data": ["Edit Profile Description ", 930, 0, 0.0, 130.95161290322574, 108, 524, 126.0, 140.0, 150.0, 344.7999999999988, 4.281018974580874, 0.9197501703201098, 2.5167709206032094], "isController": false}, {"data": ["Add Certifications", 450, 0, 0.0, 46.72888888888891, 37, 329, 44.0, 50.0, 53.44999999999999, 189.290000000002, 2.0813868511854654, 0.4276147855940278, 1.699257233975634], "isController": false}, {"data": ["Sign  In", 484, 0, 0.0, 172.59504132231396, 136, 914, 156.0, 177.0, 195.0, 832.0, 2.249499207562779, 1.080814072383679, 0.7818663683020465], "isController": false}, {"data": ["Add Skills", 450, 0, 0.0, 46.599999999999994, 38, 326, 44.0, 51.0, 54.0, 72.92000000000007, 2.0793959585784325, 0.43238620216811685, 1.3016531342273197], "isController": false}, {"data": ["Delete Language", 450, 32, 7.111111111111111, 44.87555555555556, 3, 347, 43.0, 51.0, 58.0, 222.9000000000001, 2.0790597105948883, 0.3834529658941805, 1.3071095323732698], "isController": false}, {"data": ["Delete Certifications", 448, 95, 21.205357142857142, 39.04017857142862, 3, 383, 42.0, 50.0, 53.549999999999955, 222.15999999999985, 2.090380981265894, 0.5193417837062269, 1.2174735859015935], "isController": false}, {"data": ["Update Language", 453, 0, 0.0, 163.00883002207513, 39, 420, 164.0, 187.60000000000002, 208.5999999999999, 388.3599999999997, 2.090003967777952, 0.4400266830183717, 1.314006551735672], "isController": false}, {"data": ["Sign Out", 384, 0, 0.0, 4.843749999999999, 2, 39, 4.0, 7.0, 8.0, 16.09999999999968, 1.8248088465212207, 3.6015026160345576, 0.4847148498571992], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 127, 100.0, 1.3604713444027852], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 9335, 127, "500/Internal Server Error", 127, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Language", 450, 32, "500/Internal Server Error", 32, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Certifications", 448, 95, "500/Internal Server Error", 95, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
