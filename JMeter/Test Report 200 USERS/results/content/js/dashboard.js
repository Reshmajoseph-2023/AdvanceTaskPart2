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

    var data = {"OkPercent": 98.4453589391861, "KoPercent": 1.5546410608139003};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.8223920569599582, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [0.9979674796747967, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.4375, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [0.9952445652173914, 500, 1500, "Add Education"], "isController": false}, {"data": [0.63125, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5890625, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [0.9993215739484396, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.012063492063492064, 500, 1500, "Search Skills by Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [0.9993279569892473, 500, 1500, "Add Language"], "isController": false}, {"data": [0.9882539682539683, 500, 1500, "Edit Profile Description "], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications"], "isController": false}, {"data": [0.955952380952381, 500, 1500, "Sign  In"], "isController": false}, {"data": [0.9993234100135318, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.9174560216508796, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.7561141304347826, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [0.9979784366576819, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Sign Out"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 15309, 238, 1.5546410608139003, 2926.2006662747385, 1, 137911, 68.0, 6191.0, 14607.5, 53823.399999999994, 40.22216909127692, 35.31099707115664, 26.270275581564906], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["ViewShareSkill", 640, 0, 0.0, 9.865624999999996, 1, 87, 8.0, 18.0, 19.0, 32.180000000000064, 1.8505560342584186, 0.31806431838816573, 1.060816789169621], "isController": false}, {"data": ["Update Skills", 738, 0, 0.0, 146.41869918699177, 38, 812, 159.0, 184.0, 257.0, 336.22, 2.0425842842790205, 0.4399040973119812, 1.308822466074557], "isController": false}, {"data": ["AddShareSkill", 640, 0, 0.0, 3922.7656250000005, 73, 54764, 1385.0, 7548.5999999999985, 11224.749999999998, 51414.95, 1.8498392952112286, 0.40465234582745624, 3.0439250121395705], "isController": false}, {"data": ["Add Education", 736, 0, 0.0, 55.19565217391308, 38, 688, 45.0, 59.0, 111.0, 407.27999999999884, 2.039967848332825, 0.444250810720918, 1.44032886166468], "isController": false}, {"data": ["DeleteShareSkill", 640, 0, 0.0, 8567.131249999995, 147, 96229, 398.0, 45586.6, 45907.29999999999, 95648.19, 1.8377866157446625, 0.34099556346824794, 1.0606756737354448], "isController": false}, {"data": ["Delete Education", 735, 0, 0.0, 6.480272108843535, 1, 153, 3.0, 6.0, 30.199999999999932, 85.63999999999999, 2.0376592701021323, 0.43777835881100496, 1.4247695677667254], "isController": false}, {"data": ["Disable/Enable", 640, 0, 0.0, 7957.4703125, 107, 95650, 477.0, 45640.799999999996, 50980.8, 54900.90000000001, 1.8445558223116318, 0.3422515685929786, 1.046569270276424], "isController": false}, {"data": ["Delete Skills", 737, 0, 0.0, 39.9837177747625, 1, 529, 41.0, 51.0, 88.10000000000002, 141.10000000000002, 2.0406694060184516, 0.41272633917199214, 1.3075850532733777], "isController": false}, {"data": ["Search Skills by Categories", 1575, 0, 0.0, 19518.78412698412, 1010, 137911, 11519.0, 51548.40000000001, 81671.99999999994, 124988.96, 4.171842842044759, 24.448465717881444, 3.0351786301985797], "isController": false}, {"data": ["Update Education", 736, 0, 0.0, 6.145380434782605, 1, 107, 2.0, 4.300000000000068, 44.44999999999993, 91.88999999999999, 2.040312811002165, 0.442333441447735, 1.1237660404347862], "isController": false}, {"data": ["Add Language", 744, 0, 0.0, 55.18010752688175, 38, 566, 50.0, 62.0, 90.0, 149.0, 2.0598633956183603, 0.42207602875502853, 1.3980518163620708], "isController": false}, {"data": ["Edit Profile Description ", 1575, 0, 0.0, 155.20698412698428, 109, 1741, 129.0, 170.4000000000001, 301.39999999999964, 769.2, 4.287907827677832, 0.9212301973526593, 2.5208208127559133], "isController": false}, {"data": ["Add Certifications", 737, 0, 0.0, 49.584803256445056, 36, 422, 43.0, 55.0, 106.20000000000005, 136.62, 2.0407824199193656, 0.4202423697374396, 1.6661075225122943], "isController": false}, {"data": ["Sign  In", 840, 0, 0.0, 260.78690476190474, 138, 1334, 173.0, 473.9, 908.7499999999942, 1265.0, 2.3469390606097016, 1.1276308767773173, 0.8157288529265492], "isController": false}, {"data": ["Add Skills", 739, 0, 0.0, 54.39512855209746, 37, 530, 44.0, 67.0, 116.0, 336.0, 2.045821983035457, 0.4259470707580338, 1.2806366124274688], "isController": false}, {"data": ["Delete Language", 739, 60, 8.119079837618404, 48.01759133964813, 3, 678, 42.0, 63.0, 103.0, 199.4000000000002, 2.045640764444051, 0.38060029625805525, 1.285756650927597], "isController": false}, {"data": ["Delete Certifications", 736, 178, 24.184782608695652, 41.91440217391304, 3, 642, 41.0, 52.30000000000007, 91.0, 147.29999999999995, 2.0401487978090573, 0.49605838609261615, 1.1872083831127793], "isController": false}, {"data": ["Update Language", 742, 0, 0.0, 166.932614555256, 38, 844, 162.0, 212.70000000000005, 289.4000000000001, 427.5600000000004, 2.0537006745105852, 0.434051203089408, 1.2908337779097092], "isController": false}, {"data": ["Sign Out", 640, 0, 0.0, 5.5484374999999995, 2, 416, 4.0, 8.0, 10.0, 17.0, 1.8387739974372088, 3.629064696113866, 0.4884243430692586], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 238, 100.0, 1.5546410608139003], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 15309, 238, "500/Internal Server Error", 238, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Language", 739, 60, "500/Internal Server Error", 60, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Certifications", 736, 178, "500/Internal Server Error", 178, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
