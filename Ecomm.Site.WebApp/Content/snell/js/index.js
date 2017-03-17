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
    $('a.cart').each(function (index) {
        $(this).bind('click', function () {
            var pro = $(this).attr("data-pno");
            addCart(pro);
            return false;
        });
    });
    
});

function reloadWindow() {
    window.location.href = window.location.href;
    window.location.reload();
}

function checkLogin() {
    if ($("#hdUserid").val() == '') {
        bootbox.alert({ message: "Please login the site!" });
        return;
    }
}

function deleCart(id) {
    checkLogin();
    if (id == '' || id == undefined) {
        bootbox.alert({ message: "Product sku is empty!" });
        return;
    }
    var post_data = { id: id };
    $.ajax({
        type: "POST",
        dataType: 'json',
        url: "/Home/DeleCart",
        data: post_data,
        success: function (d) {
            bootbox.alert(d.message, function () {
                //bind shopping cart
                $("#shopping_cart").load('/Home/ShoppingCart' + '?ts=' + Math.random());
                //reloadWindow();
            });
        },
        error: function (err) {
            alert(err);
        }
    });
}

function RemoveCartItem(id,me) {
    deleCart(id);
    $(me).parent().parent().remove();
    var count = $("#hdItemcount").val();
    count = count - 1;
    $("#hdItemcount").val(count);
    if (count == 0) {
        $("div.cart-content").hide();
        $("div.cart-bottom").hide();
        $("div.no_purchase").show();
    } else {
        $("div.cart-content").show();
        $("div.cart-bottom").show();
        $("div.no_purchase").hide();
    }
}

//add cart
function addCart(pro) {
    checkLogin();
    //var pro = $(this).attr("data-pno");
    //console.log($(this));
    //console.log(pro);
    if (pro == '' || pro == undefined) {
        bootbox.alert({ message: "Product sku is empty!" });
        return;
    }
    var post_data = { pno: pro, qty: 1 };
    $.ajax({
        type: "POST",
        dataType: 'json',
        url: "/Home/AddCart",
        data: post_data,
        success: function (d) {
            bootbox.alert(d.message, function () {
                //bind shopping cart
                $("#shopping_cart").load('/Home/ShoppingCart' + '?ts=' + Math.random());
            });
        },
        error: function (err) {
            alert(err);
        }
    });
}


function CheckShipTo() {
    var pno = arguments[0] ? arguments[0] : false;
    var v = $("input[name=ShipTo]:checked");
    //alert(v + 'val: ' + v.val());
    if (v == undefined || v.val() == '' || v.val() == undefined) {
        alert("Please select deliver address.");
        return false;
    } else {
        if (v.val() == "SHIPTONEW") {
            if ($(".company").val().length <= 0) {
                alert("Please enter the company!");
                return false;
            }
            if ($(".city").val().length <= 0) {
                alert("Please enter the city!");
                return false;
            }
            if ($(".address").val().length <= 0) {
                alert("Please enter the address!");
                return false;
            }
        }
    }

    if (pno) {
        if ($(".purchaseNo").val().length <= 0) {
            alert("Please enter the purchase no.");
            return false;
        }
    }
    return true;
}

function disabledShipToNEW(t) {
    $("div.new-info .purchase-table input[type=text]").each(function () {
        if (t) {
            $(this).attr("disabled", true);
        } else {
            $(this).removeAttr("disabled");
        }
    });
}

function clickShipTo(v) {
    disabledShipToNEW(v);
}

/*******初始化*********/
function InitDatatables(dataTableObj, actionUrl, aoColumns, oTable) {
    oTable = dataTableObj.dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        'bLengthChange': true,
        "bFilter": false,
        "bInfo": false,
        'bPaginate': true,
        "bProcessing": true,
        "bAutoWidth": false,
        "bServerSide": true,
        "bStateSave": false,
        "iDisplayLength": 10,
        "aLengthMenu": [[10, 20, 50, 100], [10, 20, 50, 100]],
        "oLanguage": {
            "sLengthMenu": "Show _MENU_ Items",
            "sZeroRecords": "对不起，查询不到任何相关数据",
            "sInfo": "当前显示 _START_ 到 _END_ 条，共 _TOTAL_ 条记录",
            "sInfoEmtpy": "找不到相关数据",
            "sInfoFiltered": "数据表中共为 _MAX_ 条记录",
            "sProcessing": "Loading...",
            "sSearch": "Search",
            "oPaginate": {
                "sFirst": "First",
                "sPrevious": " Previous ",
                "sNext": " Next ",
                "sLast": " Last "
            }
        },
        "sAjaxSource": actionUrl,
        "aoColumns": aoColumns
    });
    //初始化下拉框
    //$('select').select2();

    return oTable;
}