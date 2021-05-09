(function () {
    var clock;

    window.ClockFunctions = {
        startTime(elementId, endDate) {

            var x = setInterval(function () {

                var countDownDate = new Date(endDate).getTime();
                var now = new Date().getTime();

                // Find the distance between now and the count down date
                var distance = countDownDate - now;

                // Time calculations for days, hours, minutes and seconds
                var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                
                let timeString;

                timeString = days > 0 ? `${days}d `: "";

                timeString = `${timeString}${hours}h ${minutes}m ${seconds}s`;

                var searchElement = document.getElementById(elementId);

                searchElement.innerHTML = timeString;

                // If the count down is finished, write some text
                if (distance < 0) {
                    clearInterval(x);
                    searchElement.innerHTML = "Finished";
                }
            }, 1000);
        },
        stopTime() {
            clearTimeout(clock);
        }
    };
})();
