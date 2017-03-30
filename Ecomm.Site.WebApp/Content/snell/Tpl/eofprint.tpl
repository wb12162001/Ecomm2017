<div class="hide">
	{#param name=mon0 value=eobj.monName[getMonth(0)]}
	{#param name=mon1 value=eobj.monName[getMonth(1)]}
	{#param name=mon2 value=eobj.monName[getMonth(2)]}
	{#param name=mon3 value=eobj.monName[getMonth(3)]}
	show: {$P.mon0}<br/>
</div>
  <div class="clearfloat Orders_pro red ItemNumber invoice_item">
    <p class="floatleft w_120 eofprintpadding">Product No.</p>
    <p class="floatleft w_380">Description</p>
    <p class="floatleft w_50">Unit</p>
    <p class="floatleft w_80 text-center">{$P.mon3}</p>
    <p class="floatleft w_80 text-center">{$P.mon2}</p>
    <p class="floatleft w_80 text-center">{$P.mon1}</p>
    <p class="floatleft w_80 text-center">{$P.mon0}</p>
    <p class="floatleft w_80 text-center">Qty</p>
  </div>
<div class="{#if $P.show == 0}hide{#/if}">
  {#foreach $T.d as post}
  <div class="invoice_item Orders_item">
    <p class="w_120 floatleft eofprintpadding">{$T.post.ProductNo}</p>
    <p class="w_380 floatleft">{$T.post.ProductName}</p>
    <p class="w_50 floatleft">{$T.post.BaseUOFM}</p>
    <p class="w_80 floatleft text-center">{$T.post.QTY3}</p>
    <p class="w_80 floatleft text-center">{$T.post.QTY2}</p>
    <p class="w_80 floatleft text-center">{$T.post.QTY1}</p>
    <p class="w_80 floatleft text-center">{$T.post.QTY0}</p>
    <p class="w_80 floatleft text-center">
      <input type="text" class="w_50 inputheight"></input>
    </p>
  </div>
  {#/for}
</div>