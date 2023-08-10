for (let i = 0; i < 10; i++) {
    var markup = "<tr>"
        + " <td class='formNumber' > </td >"
        + " <td class='formName' > </td >"
        + " <td class='occurence' > </td >"
        + " <td class='claimsmade' > </td >"
        + " <td class='effectiveDate' > </td >"
        + " <td class='expirationDate' > </td >"
        + " <td class='action' ></td >"
        + "</tr>";
    jQuery(".form-tablebody").append(markup);
}