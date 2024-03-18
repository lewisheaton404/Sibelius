var plays = document.querySelectorAll('.play-video');
if (plays.length) {
    Array.from(plays).forEach(x => {
        x.addEventListener('click', () => {
            var targetId = x.getAttribute('data-id');
            var modal = document.querySelector('.video-modal[data-id="' + targetId + '"]');
            if (modal !== undefined) {
                modal.classList.add('active');
            }
        });
    });
}

var closes = document.querySelectorAll('.modal .close');
if (closes.length) {
    Array.from(closes).forEach(x => {
        x.addEventListener('click', () => {
            var targetId = x.getAttribute('data-id');
            var modal = document.querySelector('.video-modal[data-id="' + targetId + '"]');
            if (modal !== undefined) {
                modal.classList.remove('active');
                stopVideos();
            }
        });
    });
}

var stopVideos = function () {
    var videos = document.querySelectorAll('iframe, video');
    Array.prototype.forEach.call(videos, function (video) {
        if (video.tagName.toLowerCase() === 'video') {
            video.pause();
        } else {
            var src = video.src;
            video.src = src;
        }
    });
};