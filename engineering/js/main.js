$(document).ready(function(){
    adjustMaxContent();
    if ($(this).scrollTop() > 0){  
        $('header').addClass("sticky");
    }
    else{
        $('header').removeClass("sticky");
    }

    let multiselect = $('.select2me');
    if(multiselect && multiselect.length){
        multiselect.select2({
            width: '100%'
        });
    }
    
    $('.has-submenu').hover(
        function(){
            if($(this).hasClass('menu-item')){
                if($(this).hasClass('has-megamenu')){
                    $('body').addClass('megamenu-open');
                }else{
                    $('body').addClass('submenu-open');
                }
            }
            $(this).children('.submenu').fadeIn(300)
            
        },
        function(){
            if($(this).hasClass('menu-item')){
                $('body').removeClass('megamenu-open submenu-open');
            }
            $(this).children('.submenu').fadeOut(300)
        }
    );
    $('.megamenu-item').hover(
        function(){
            if($(this).hasClass('active')){
                return;
            }
            $('.megamenu-item').removeClass('active');
            $(this).addClass('active');
            let target = $(this).data('target');
            $('.mega-submenu').removeClass('show')
            if(!target) return;
            $(target).addClass('show');
        }
    );
    $('.sidebar-toggler').click(function(){
        $('.desktop-sidebar').addClass('show')
        $('.desktop-sidebar').removeClass('hide')
    });
    $('.sidebar-close-button').click(function(){
        $('.desktop-sidebar').removeClass('show');
        $('.desktop-sidebar').addClass('hide');
    });
    $('.desktop-sidebar').click(function(e){
        if(!e.target.closest('.sidebar-content')) {
            $('.desktop-sidebar').removeClass('show');
            $('.desktop-sidebar').addClass('hide');
        } 
    })

    var homebannerSwiper = new Swiper(".home-banner-slider", {
        loop: true,
        autoplay: {
            delay: 5000,
            // disableOnInteraction: true,
        },
        pagination: {
            el: ".home-banner-pagination",
        },
    });
    var noticeSwiper = new Swiper(".notice-slider", {
        loop:true,
        spaceBetween: 20,
        autoplay: {
            delay: 2500,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".notice-next",
            prevEl: ".notice-prev",
          },
    });
    var factSwiper = new Swiper(".factslider", {
        loop:true,
        spaceBetween: 20,
        autoplay: {
            delay: 2500,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
    var lifeAtSwiper = new Swiper(".lifeAt-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".lifeAt-next",
            prevEl: ".lifeAt-prev",
        },
        breakpoints:{
            640:{
                slidesPerView: 2,
            },
            992:{
                slidesPerView: 3,
                spaceBetween: 20,
            },
            1350:{
                slidesPerView: 4,
                spaceBetween: 20,
            }
        }
    });    
    var placementTestimonialsSlider = new Swiper(".placement-testimonial-slider", {
        loop:true,
        spaceBetween: 20,
        autoplay: {
            delay: 2500,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".placement-testimonial-next",
            prevEl: ".placement-testimonial-prev",
        },
    });
    var recruitersSwiper = new Swiper(".recruiters-slider", {
        slidesPerView: 2,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 2000,
            disableOnInteraction: false,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        breakpoints:{
            575:{
                slidesPerView: 3,
            },
            992:{
                slidesPerView: 4,
                spaceBetween: 20,
            },
            1320:{
                slidesPerView: 5,
                spaceBetween: 20,
            }
        }
    });    
    var testimonialsTab1Swiper = new Swiper(".testimonialsTab1-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        }
    });   
    var testimonialsTab2Swiper = new Swiper(".testimonialsTab2-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        }
    });
    var testimonialsTab3Swiper = new Swiper(".testimonialsTab3-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        }
    }); 
    var testimonialsTab4Swiper = new Swiper(".testimonialsTab4-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        }
    });
    var testimonialsTab5Swiper = new Swiper(".testimonialsTab5-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        }
    });
    var testimonialsTab6Swiper = new Swiper(".testimonialsTab6-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        }
    });
    var eventPhotosSwiper = new Swiper(".event-photos-slider", {
        slidesPerView: 1,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        breakpoints:{
            640:{
                slidesPerView: 2,
            },
            1320:{
                slidesPerView: 3,
                spaceBetween: 20,
            }
        }
    });
    var hostalEventsSwiper = new Swiper(".hostalEvents", {
        slidesPerView: 1.3,
        spaceBetween: 10,
        loop: true,
        observer: true,
        autoplay: {
            delay: 6000,
            disableOnInteraction: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        breakpoints:{
            640:{
                slidesPerView: 2.5,
            },
            1200:{
                slidesPerView: 3.5,
                spaceBetween: 20,
            }
        }
    });

    // footer navigation
    $('.foot-nav a').click(function(){
        let target = $(this).data('target');
        if($(this).hasClass('active')){
            $(this).removeClass('active');
            $('.mobile-menu-container').find(target).removeClass('show');
        }else{
            $('.foot-nav a.active').removeClass('active')
            $(this).addClass('active');
            $('.mobile-menu-container .drop-menu').removeClass('show');
            $('.mobile-menu-container').find(target).addClass('show');
        }
    });


    $(document).on('click', '.gallery-detail .video', function(){
        //console.log(myImageModal);
        let videosrc = $(this).data('videosrc');
        let title = $(this).data('title');
        if(videosrc && videosrc != ''){            
            // let srcLink = `https://www.youtube.com/embed/${videosrc}`;
            $('#video-modal').find('iframe').attr('src', videosrc);
            $("#video-modal").modal('show');
            if(title && title != ''){
                $('#video-modal').find('.modal-title').html(title);
                $('#video-modal').find('.modal-title').addClass('d-block');
            }else{
                $('#video-modal').find('.modal-title').removeClass('d-block');
            }
        }
    })
    $('#video-modal').on('hide.bs.modal', function(){
        let src = '';
        $('#video-modal').find('iframe').attr('src', src);
        $('#video-modal').find('.modal-title').html('');
        $('#video-modal').find('.modal-title').removeClass('d-block');
    });

    AOS.init({
        offset: 200,
        mirror: false,
    });


    var thumbSwiper = new Swiper(".sportFacilityThumb", {
        loop: true,
        spaceBetween: 30,
        slidesPerView: 1,
        watchSlidesProgress: true,
        noSwiping: true,
        noSwipingClass: 'swiper-no-swiping',
        observer: true,
        
    });
    var swiper2 = new Swiper(".sportFacilitySwiper", {
        loop: true,
        spaceBetween: 16,
        slidesPerView: 1.75,
        observer: true,
        thumbs: {
          swiper: thumbSwiper,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });
});
$(window).scroll(function() {
    if ($(this).scrollTop() > 0){  
        $('header').addClass("sticky");
    }
    else{
        $('header').removeClass("sticky");
    }
});


$(function() {
    $(window).scroll(function() {
      $("[data-count]").each(function() {
        if($(this).hasClass('no-animate')){
            return
        }else{
            inVisible($(this));
        }
      });
    })
});

function inVisible(element) {
    var WindowTop = $(window).scrollTop();
    var WindowBottom = WindowTop + $(window).height();
    var ElementTop = element.offset().top;
    var ElementBottom = ElementTop + element.height();
    if ((ElementBottom <= WindowBottom) && ElementTop >= WindowTop) animate(element);
}

function animate(element) {
    if (!element.hasClass('ms-animated')) {
      var maxval = element.data('count');
      let maxvalLength = `${maxval}`.length;
      var html = element.html();
      element.addClass("ms-animated");
      $({
        countNum: element.html()
      }).animate({
        countNum: maxval
      }, {
        //duration 2 seconds
        duration: 1500,
        easing: 'swing',
        step: function() {
            let abc = Math.floor(this.countNum);
            if(!element.hasClass('non-zero')){

                abc = (`${abc}`.length >= maxvalLength) ? abc : `00000${abc}`.substring(`00000${abc}`.length - maxvalLength);
                // abc = abc > 9 ? `${abc}` : `0${abc}`;
            }
          element.html(abc + html);
        },
        complete: function() {
            let abc = Math.floor(this.countNum);
            if(!element.hasClass('non-zero')){
                abc = abc > 9 ? `${abc}` : `0${abc}`;
            }
          element.html(abc + html);
        }
      });
    }
}



$(window).resize(function(){
    adjustMaxContent();
});
function adjustMaxContent(){
    let containerWidth = $('footer .container').width();
    containerWidth += 30;
    let windowWidth = $("body").width();
    windowWidth = windowWidth > 1920 ? 1920 : windowWidth;
    let maxContentWidth = windowWidth - ((windowWidth - containerWidth) / 2);
    if(windowWidth >= 1400){
        $('.max-content-xxl').css('max-width', `${maxContentWidth}px`);
        $('.max-content-xl').css('max-width', `${maxContentWidth}px`);
        $('.max-content-lg').css('max-width', `${maxContentWidth}px`);
        $('.max-content-md').css('max-width', `${maxContentWidth}px`);
        $('.max-content-sm').css('max-width', `${maxContentWidth}px`);
        $('.max-content').css('max-width', `${maxContentWidth}px`);
    }else if(windowWidth >= 1200){
        $('.max-content-xxl').css('max-width', '');
        $('.max-content-xl').css('max-width', `${maxContentWidth}px`);
        $('.max-content-lg').css('max-width', `${maxContentWidth}px`);
        $('.max-content-md').css('max-width', `${maxContentWidth}px`);
        $('.max-content-sm').css('max-width', `${maxContentWidth}px`);
        $('.max-content').css('max-width', `${maxContentWidth}px`);
    }else if(windowWidth >= 992){
        $('.max-content-xxl').css('max-width', '');
        $('.max-content-xl').css('max-width', '');
        $('.max-content-lg').css('max-width', `${maxContentWidth}px`);
        $('.max-content-md').css('max-width', `${maxContentWidth}px`);
        $('.max-content-sm').css('max-width', `${maxContentWidth}px`);
        $('.max-content').css('max-width', `${maxContentWidth}px`);
    }else if(windowWidth >= 768){
        $('.max-content-xxl').css('max-width', '');
        $('.max-content-xl').css('max-width', '');
        $('.max-content-lg').css('max-width', '');
        $('.max-content-md').css('max-width', `${maxContentWidth}px`);
        $('.max-content-sm').css('max-width', `${maxContentWidth}px`);
        $('.max-content').css('max-width', `${maxContentWidth}px`);
    }else if(windowWidth >= 575){
        $('.max-content-xxl').css('max-width', '');
        $('.max-content-xl').css('max-width', '');
        $('.max-content-lg').css('max-width', '');
        $('.max-content-md').css('max-width', '');
        $('.max-content-sm').css('max-width', `${maxContentWidth}px`);
        $('.max-content').css('max-width', `${maxContentWidth}px`);
    }else{
        $('.max-content-xxl').css('width', '');
        $('.max-content-xl').css('width', '');
        $('.max-content-lg').css('width', '');
        $('.max-content-md').css('width', '');
        $('.max-content-sm').css('width', '');
        $('.max-content').css('width', `${maxContentWidth}px`);
    }
}



$(document).on('click', '.single-video', function(){
        //console.log(myImageModal);
        let videoid = $(this).data('video');
        $('#video-modal').find('iframe').attr('src', '');
        $('#video-modal').find('iframe').attr('src', videoid);
        $("#video-modal").modal('show');
    })
    $('#video-modal').on('hide.bs.modal', function(){
        let src = $('#video-modal').find('iframe').attr('src');
        $('#video-modal').find('iframe').attr('src', '');
    });


    $(function () {
    $(".distinguished_faculty_video .col-lg-4.col-md-6").slice(0, 6).show();
    $("body").on('click touchstart', '.load-more', function (e) {
        e.preventDefault();
        $(".distinguished_faculty_video .col-lg-4.col-md-6:hidden").slice(0, 6).slideDown();
        if ($(".distinguished_faculty_video .col-lg-4.col-md-6:hidden").length == 0) {
            $(".load-more").css('visibility', 'hidden');
          
        }

    });
});



    $('.cara-carousel').owlCarousel({
    loop:true,
    nav:true,
    dots:true,
    autoplay:true,
    autoplayTimeout:4000,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})