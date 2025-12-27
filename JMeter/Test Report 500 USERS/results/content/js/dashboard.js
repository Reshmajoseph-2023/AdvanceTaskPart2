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

    var data = {"OkPercent": 97.86916892700926, "KoPercent": 2.1308310729907385};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.7732448745204408, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "ViewShareSkill"], "isController": false}, {"data": [0.9989909182643795, 500, 1500, "Update Skills"], "isController": false}, {"data": [0.20779584969153111, 500, 1500, "AddShareSkill"], "isController": false}, {"data": [0.9997476022211005, 500, 1500, "Add Education"], "isController": false}, {"data": [0.17756741250717153, 500, 1500, "DeleteShareSkill"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.2212138400453772, 500, 1500, "Disable/Enable"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [0.0, 500, 1500, "Search Skills by Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [0.9979438800193517, 500, 1500, "Edit Profile Description "], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications"], "isController": false}, {"data": [0.9811977715877437, 500, 1500, "Sign  In"], "isController": false}, {"data": [0.9997477295660948, 500, 1500, "Add Skills"], "isController": false}, {"data": [0.8377901109989909, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.7218576476527007, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [0.9989909182643795, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Sign Out"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 40923, 872, 2.1308310729907385, 5877.9044302714565, 1, 120819, 74.0, 42902.50000000008, 56715.200000000026, 84963.06000000032, 50.71676170198527, 43.830825317374796, 33.25068033919925], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["ViewShareSkill", 1763, 0, 0.0, 10.103233125354528, 2, 213, 6.0, 17.0, 22.0, 80.7199999999998, 2.355188628834028, 0.4047980455808486, 1.350093481567944], "isController": false}, {"data": ["Update Skills", 1982, 0, 0.0, 140.65237134207882, 39, 611, 163.0, 188.0, 214.8499999999999, 334.02000000000044, 2.5931580923671924, 0.5650812602460491, 1.6604471799405747], "isController": false}, {"data": ["AddShareSkill", 1783, 0, 0.0, 6603.625911385307, 82, 86023, 2899.0, 14034.2, 25009.8, 52146.12000000018, 2.377425260443404, 0.5200617757219946, 3.9120718396944683], "isController": false}, {"data": ["Add Education", 1981, 0, 0.0, 51.41443715295304, 38, 553, 46.0, 57.0, 82.89999999999986, 161.18000000000006, 2.5920939172806694, 0.5644892026890521, 1.8301600607362543], "isController": false}, {"data": ["DeleteShareSkill", 1743, 0, 0.0, 10805.69305794607, 157, 87987, 9804.0, 20868.600000000002, 27788.2, 54474.68, 2.2915817567478736, 0.42519583377157805, 1.3225828303105402], "isController": false}, {"data": ["Delete Education", 1980, 0, 0.0, 5.453535353535352, 1, 167, 3.0, 6.0, 11.0, 68.0, 2.5909176559261353, 0.5566424651403806, 1.8116182047296026], "isController": false}, {"data": ["Disable/Enable", 1763, 0, 0.0, 7902.58082813386, 122, 55221, 5218.0, 14971.800000000001, 20531.4, 54314.56, 2.3141463517082417, 0.4293826238521151, 1.3130068655688363], "isController": false}, {"data": ["Delete Skills", 1982, 0, 0.0, 36.748738647830535, 1, 393, 42.0, 49.0, 62.0, 112.19000000000051, 2.593432935813189, 0.5298834018329368, 1.6606231672921261], "isController": false}, {"data": ["Search Skills by Categories", 4134, 0, 0.0, 46849.540880503126, 6259, 120819, 48162.0, 77056.5, 89447.5, 113355.20000000001, 5.129738710914283, 30.06207226972325, 3.7320852926085353], "isController": false}, {"data": ["Update Education", 1980, 0, 0.0, 4.340909090909081, 1, 116, 2.0, 5.0, 11.0, 63.190000000000055, 2.5909278269574263, 0.5617050562349107, 1.4270344671913948], "isController": false}, {"data": ["Add Language", 1982, 0, 0.0, 55.91977800201811, 38, 479, 51.0, 67.70000000000005, 90.0, 141.0, 2.5933650678174125, 0.5386006856486946, 1.760145236458107], "isController": false}, {"data": ["Edit Profile Description ", 4134, 0, 0.0, 142.06748911465812, 108, 688, 129.0, 164.0, 215.25, 407.0, 5.3487905703953365, 1.1491542241083732, 3.144503831423821], "isController": false}, {"data": ["Add Certifications", 1981, 0, 0.0, 47.78192831903081, 36, 331, 44.0, 54.799999999999955, 70.0, 132.0, 2.5921278346900243, 0.5352599124191841, 2.1162293650399024], "isController": false}, {"data": ["Sign  In", 2154, 0, 0.0, 218.48839368616552, 136, 1135, 173.0, 354.5, 471.0, 740.1499999999987, 2.7913884241614495, 1.3411749069213215, 0.9702196319067101], "isController": false}, {"data": ["Add Skills", 1982, 0, 0.0, 50.97880928355203, 38, 576, 45.0, 60.0, 79.0, 141.6800000000003, 2.5931716635156974, 0.5418058674270425, 1.6232646838999627], "isController": false}, {"data": ["Delete Language", 1982, 321, 16.195761856710394, 42.435923309788095, 3, 553, 42.0, 52.0, 71.84999999999991, 139.17000000000007, 2.5932666655327123, 0.47242381829404395, 1.626481456327924], "isController": false}, {"data": ["Delete Certifications", 1981, 551, 27.814235234729935, 37.30136294800604, 2, 482, 42.0, 51.0, 70.0, 136.90000000000032, 2.5922126320968526, 0.6135698745079899, 1.5069047941703348], "isController": false}, {"data": ["Update Language", 1982, 0, 0.0, 152.1791120080732, 38, 681, 164.0, 200.0, 234.0, 361.34000000000015, 2.5932768447331096, 0.5512985131345155, 1.6264878406619792], "isController": false}, {"data": ["Sign Out", 1654, 0, 0.0, 5.983071342200731, 2, 205, 4.0, 8.0, 11.0, 44.90000000000009, 2.22385059596238, 4.389064506289033, 0.5907103145525072], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 872, 100.0, 2.1308310729907385], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 40923, 872, "500/Internal Server Error", 872, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Language", 1982, 321, "500/Internal Server Error", 321, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Certifications", 1981, 551, "500/Internal Server Error", 551, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
