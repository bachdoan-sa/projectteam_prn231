function countdownclock(element, days, hours, minutes, seconds) {
    let el = document.getElementById(element);
    el.style.display = "flex";
    let countDate = new Date(el.value).getTime();
    let t = setInterval(function () {
        // Get the current date and time
        let now = new Date().getTime();

        // Calculate the distance between now and the countdown date
        let distance = countDate - now;

        // Calculate days, hours, minutes and seconds
        let day = Math.floor(distance / (1000 * 60 * 60 * 24));
        let hour = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        let minute = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        let second = Math.floor((distance % (1000 * 60)) / 1000);

        // Display the result
        document.getElementById(days).innerHTML = day.
            toString().padStart(2, '0');
        document.getElementById(hours).innerHTML = hour.
            toString().padStart(2, '0');
        document.getElementById(minutes).innerHTML = minute.
            toString().padStart(2, '0');
        document.getElementById(seconds).innerHTML = second.
            toString().padStart(2, '0');

        // If the countdown is over, display a message
        if (distance < 0) {
            clearInterval(t);
            document.getElementById(element).innerHTML = "EXPIRED";
        }
    }, 1000);
}