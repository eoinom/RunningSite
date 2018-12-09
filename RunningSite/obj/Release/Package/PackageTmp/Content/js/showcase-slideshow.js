// Script for the showcase slideshow
var showcaseSlideIndex = 1;
var showcaseTimer = null;
showshowcaseSlides(showcaseSlideIndex);

function plusShowcaseSlides(n) {
  clearTimeout(showcaseTimer);
  showshowcaseSlides(showcaseSlideIndex += n);
}

function currentShowcaseSlide(n) {
  clearTimeout(showcaseTimer);
  showshowcaseSlides(showcaseSlideIndex = n);
}

function showshowcaseSlides(n) {
  var i;
  var showcaseSlides = document.getElementsByClassName("showcaseSlides");
  var showcaseDots = document.getElementsByClassName("showcase-dot");

  if (n==undefined){n = ++showcaseSlideIndex}
  if (n > showcaseSlides.length) {showcaseSlideIndex = 1}
  if (n < 1) {showcaseSlideIndex = showcaseSlides.length}

  for (i = 0; i < showcaseSlides.length; i++) {
    showcaseSlides[i].style.display = "none";
  }

  for (i = 0; i < showcaseDots.length; i++) {
    showcaseDots[i].className = showcaseDots[i].className.replace(" active", "");
  }

  showcaseSlides[showcaseSlideIndex-1].style.display = "block";
  showcaseDots[showcaseSlideIndex-1].className += " active";
  showcaseTimer = setTimeout(showshowcaseSlides, 4000); // Change showcase every 4 seconds
}
