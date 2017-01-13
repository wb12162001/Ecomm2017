$(function () {
    //删除左右两端的空格
    function trim(str) {
        return str.replace(/(^\s*)|(\s*$)/g, "");
    }

    //打开ALL CATEGORY
    $('.show-menu').hover(function () {
        $('.dd').show();
    }, function () {
        $('.dd').hide();
    })

    $('.dd').hover(function () {
        $(this).show();
    }, function () {
        $(this).hide();
    })



    //下拉菜单
    $('.dropdown-toggle').hover(function () {
        $(this).next().show();
    },
    function () {
        $(this).next().hide();
    })

    $('.dropdown-menu').hover(function () {
        $(this).prev().addClass('nav-active');
        $(this).show();
    }, function () {
        $(this).prev().removeClass('nav-active');
        $(this).hide();
    })


    //左菜单栏
    $(".dd-inner").children(".item").hover(function () { //一级导航悬浮
        $(this).addClass("hover").siblings(".item").removeClass("hover");
        var index = $(this).index();
        $(".dorpdown-layer").children(".item-sub").hide();
        $(".dorpdown-layer").children(".item-sub").eq(index).show();

    })

    $(".dd-inner").hover(function () { //整个导航菜单悬浮，是否显示二级导航到出厂
        $("#index_menus_sub").show();
    }, function () {
        $("#index_menus_sub").hide();
        $('.item').removeClass("hover");
    })

    $("#index_menus_sub").children(".item-sub").hover(function () { //二级导航悬浮
        var index = $(this).index();
        $(".dd-inner").children(".item").eq(index).addClass("hover");
        $("#index_menus_sub").show();
    }, function () {
        $("#index_menus_sub").hide();
        $(".dd-inner").children(".item").removeClass("hover");
    })

    //倒计时
    var intDiff = parseInt(3600 * 25);//倒计时总秒数量
    function timer(intDiff) {
        window.setInterval(function () {
            var day = 0,
		        hour = 0,
		        minute = 0,
		        second = 0;//时间默认值        
            if (intDiff > 0) {
                day = Math.floor(intDiff / (60 * 60 * 24));
                hour = Math.floor(intDiff / (60 * 60)) - (day * 24);
                minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
                second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
            }
            if (minute <= 9) minute = '0' + minute;
            if (second <= 9) second = '0' + second;
            $('.days .num').html(day);
            $('.hrs .num').html(hour);
            $('.mins .num').html(minute);
            $('.secs .num').html(second);
            intDiff--;
        }, 1000);
    }
    timer(intDiff);



    //点击加载
    $('.protect-btn').click(function () {
        $(this).addClass('active').siblings().removeClass('active');
        var content = '<div class="equipment-box pull-left"><a href="#"><img class="pro-img" src="images/protection-' + parseInt(2 * Math.random() + 1) + '.jpg" /></a><p class="star-line"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-2.png"></p><a href="#"><p class="equipment-name">SPILLSOL 200 LITRE MOBILE KIT UNIVERSAL</p></a><div class="price-cart"><div class="price pull-left"><p class="old-price">$519.99</p><p class="new-price">$460.00</p></div><div class="cart pull-left"><a href="#"><img src="images/cart_03.png"></a></div></div><div class="wishlist-compare"><div class="wishlist pull-left"><a href="#"><i class="fa fa-heart-o"></i> <span>wishlist</span></a></div><div class="compare pull-right"><a href="#"><i class="fa fa-exchange"></i> <span>compare</span></a></div></div><div class="clearfix"></div><span class="label label-danger is-sale">SALE!</span></div>';
        content += '<div class="equipment-box pull-left"><a href="#"><img class="pro-img" src="images/protection-' + parseInt(2 * Math.random() + 1) + '.jpg" /></a><p class="star-line"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-2.png"></p><a href="#"><p class="equipment-name">SPILLSOL 200 LITRE MOBILE KIT UNIVERSAL</p></a><div class="price-cart"><div class="price pull-left"><p class="old-price">$519.99</p><p class="new-price">$460.00</p></div><div class="cart pull-left"><a href="#"><img src="images/cart_03.png"></a></div></div><div class="wishlist-compare"><div class="wishlist pull-left"><a href="#"><i class="fa fa-heart-o"></i> <span>wishlist</span></a></div><div class="compare pull-right"><a href="#"><i class="fa fa-exchange"></i> <span>compare</span></a></div></div><div class="clearfix"></div><span class="label label-danger is-sale">SALE!</span></div>';
        content += '<div class="equipment-box pull-left"><a href="#"><img class="pro-img" src="images/protection-' + parseInt(2 * Math.random() + 1) + '.jpg" /></a><p class="star-line"><img src="images/star-1.png"><img src="images/star-' + parseInt(2 * Math.random() + 1) + '.png"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-2.png"></p><a href="#"><p class="equipment-name">SPILLSOL 200 LITRE MOBILE KIT UNIVERSAL</p></a><div class="price-cart"><div class="price pull-left"><p class="old-price">$519.99</p><p class="new-price">$460.00</p></div><div class="cart pull-left"><a href="#"><img src="images/cart_03.png"></a></div></div><div class="wishlist-compare"><div class="wishlist pull-left"><a href="#"><i class="fa fa-heart-o"></i> <span>wishlist</span></a></div><div class="compare pull-right"><a href="#"><i class="fa fa-exchange"></i> <span>compare</span></a></div></div><div class="clearfix"></div><span class="label label-danger is-sale">SALE!</span></div>';
        content += '<div class="equipment-box pull-left"><a href="#"><img class="pro-img" src="images/protection-1.jpg" /></a><p class="star-line"><img src="images/star-1.png"><img src="images/star-1.png"><img src="images/star-' + parseInt(2 * Math.random() + 1) + '.png"><img src="images/star-1.png"><img src="images/star-2.png"></p><a href="#"><p class="equipment-name">SPILLSOL 200 LITRE MOBILE KIT UNIVERSAL</p></a><div class="price-cart"><div class="price pull-left"><p class="old-price">$519.99</p><p class="new-price">$460.00</p></div><div class="cart pull-left"><a href="#"><img src="images/cart_03.png"></a></div></div><div class="wishlist-compare"><div class="wishlist pull-left"><a href="#"><i class="fa fa-heart-o"></i> <span>wishlist</span></a></div><div class="compare pull-right"><a href="#"><i class="fa fa-exchange"></i> <span>compare</span></a></div></div><div class="clearfix"></div><span class="label label-danger is-sale">SALE!</span></div>';
        $('.equipment-box').remove();
        $('.personal-protection-list').append(content);
    })

    $('.head-pro').click(function () {
        $(this).addClass('active').siblings().removeClass('active');

    })

    //add to cart
    $('a.cart').on('click', function () {
        addCart();
    })

    //删除购物车
    $('.del-cart').on('click', function () {
        var $id = $(this).data('list-id');
        $('.list-id-' + $id).remove();
        if ($('.cart-list li').length == 0) {
            $('.cart-list').hide();
            $('.cart-layer-fun').hide();
            $('.empty-cart').show();
        }
    })


});


//add cart
function addCart() {
    if ($("#hdUserid").val() == '') {
        bootbox.alert({ message: "Please login the site!" });
        return;
    }
}