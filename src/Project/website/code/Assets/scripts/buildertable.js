jQuery(".btn-load-form").click(function () {
    var settings = {
        "url": "https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?format=json",
        "method": "GET",
        "timeout": 0,
    };
    jQuery.ajax(settings).done(function (response) {       
        for (let i = 0; i < 10; i++) {
            var requiredIndex = response.Results[i];
            var markup = "<tr>"
                + " <td class='formNumber'><b>" + requiredIndex.Country + "</b> </td >"
                + " <td class='formName'><b>" + requiredIndex.Mfr_Name + "</b></td > "
                + " <td class='occurence'><b><input type='checkbox' style='margin-left: 30px'> </b></td >"
                + " <td class='claimsmade'><b> <input type='checkbox' style='margin-left: 30px'> </b></td >"
                + " <td class='effectiveDate'><b> </b></td >"
                + " <td class='expirationDate'><b></b> </td >"
                + " <td class='action' ><i class='bi bi-plus-circle-fill'></i> </td >"
                + "</tr>";
            jQuery(".form-tablebody").append(markup);

        }
       /* var table = document.getElementById("#loadtable");*/

    });
});


