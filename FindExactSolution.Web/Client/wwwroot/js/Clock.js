(function () {
    var clock;

    window.ClockFunctions = {
        startTime(element, endDate) {
            // Update the count down every 1 second
            var x = setInterval(function () {

                var countDownDate = new Date(endDate).getTime();
                // Get today's date and time
                var now = new Date().getTime();

                // Find the distance between now and the count down date
                var distance = countDownDate - now;

                // Time calculations for days, hours, minutes and seconds
                var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                // Display the result in the element

                let timeString;

                if (days > 0) timeString = `${days}d `;

                timeString = `${timeString}${hours}h ${minutes}m ${seconds}s`;

                element.innerHTML = timeString;

                // If the count down is finished, write some text
                if (distance < 0) {
                    clearInterval(x);
                    element.innerHTML = "Finished";
                }
            }, 1000);
            //let timeString = new Date().toLocaleTimeString('en-US', { hour: 'numeric', hour12: false, minute: 'numeric', second: 'numeric' });
            //element.innerHTML = timeString;
            //clock = setTimeout(startTime.bind(null, element), 1000);
        },
        stopTime() {
            clearTimeout(clock);
        }
    };
})();
