$("#computer-vs-check").change(function () {
    loadRPSControls(this.checked);
});

$(document).ready(function () {
    loadRPSControls($("#computer-vs-check").is(":checked"));
    console.log("page loaded")
});

function loadRPSControls(isChecked) {
    if (isChecked) {
        $(".player-options").hide();
        $("#play-computer").show();
        console.log("Checked");
    }
    else {
        $(".player-options").show();
        $("#play-computer").hide();
        console.log("UnChecked");
    }
}