// ==UserScript==
// @name        Direct Download Button
// @version     0.17
// @description Direct YT Downloader
// @author      Daniel FERRERI
// @icon        https://www.youtube.com/s/desktop/2b66c0ce/img/favicon_32.png
// @match       https://www.youtube.com/*
// @run-at      document-end
// ==/UserScript==
var ytVideoLoader = {
  httpReq: null,
  vid: null,
  oldUrl: null,
  res: 0,
  DocOnLoad: function (o) {
    try {
      if (
        null != o &&
        null != o.body &&
        null != o.location &&
        ((ytVideoLoader.vid = ytVideoLoader.getVid(o)), ytVideoLoader.vid)
      ) {
        o.querySelector("#info-contents #info").setAttribute(
          "style",
          "flex-wrap: wrap;"
        );
        var t = o.querySelector("#menu-container"),
          e = o.querySelector("#directdownloader"),
          n = ytVideoLoader.GetCommandButton();
        null == e &&
          (null != t
            ? t.parentNode.insertBefore(n, t)
            : (t = o.querySelector("#eow-title")).parentNode.insertBefore(
                n,
                t
              )),
          (ytVideoLoader.oldUrl = o.location.href),
          ytVideoLoader.checkChangeVid();
      }
      return !0;
    } catch (o) {
      console.log("Fehler in der Funktion .DocOnLoad. ", o);
    }
  },
  checkChangeVid: function () {
    setTimeout(function () {
      ytVideoLoader.oldUrl == window.location.href
        ? ytVideoLoader.checkChangeVid()
        : ytVideoLoader.WaitLoadDom(window.document);
    }, 1e3);
  },
  WaitLoadDom: function (o) {
    (ytVideoLoader.vid = ytVideoLoader.getVid(o)),
      ytVideoLoader.vid
        ? null != o.querySelector("#info #menu-container")
          ? ytVideoLoader.DocOnLoad(o)
          : setTimeout(function () {
              ytVideoLoader.WaitLoadDom(o);
            }, 1e3)
        : ytVideoLoader.checkChangeVid();
  },
  directLoad: function (o) {
    try {
     var t =
     ytVideoLoader.vid;
     window.open(t, "_blank");
    } catch (o) {
      console.log("Fehler in der Funktion .OnButtonClick. ", o);
    }
  },
  GetCommandButton: function () {
    try {
      var o = document.createElement("button");
      return (
        (o.id = "directdownloader"),
        (o.className = "yt-uix-tooltip"),
        o.setAttribute("type", "button"),
        o.setAttribute("title", "Direct Download"),
        (o.innerHTML = "Direct Download "+ ytVideoLoader.res +"p"),
        o.addEventListener(
          "click",
          function (o) {
            ytVideoLoader.directLoad(o);
          },
          !0
        ),
        o.setAttribute(
          "style",
          "min-height:25px; position:relative; top:1px; cursor: pointer; font: 13px Arial; background: #819830; color: #fff; display: block; padding: 10px 16px; margin: 20px 5px 10px 5px; border: 1px solid #1F7311; border-radius: 2px; font-weight:bold"
        ),
        o.setAttribute("onmouseover", "this.style.backgroundColor='#1F7311'"),
        o.setAttribute("onmouseout", "this.style.backgroundColor='#819830'"),
        o
      );
    } catch (o) {
      console.log("Fehler in der Funktion .GetCommandButton. ", o);
    }
  },
  getVid: function (o) {
    var bestLink;
    var bestQuality = 0;
    for (var i=0; i<ytInitialPlayerResponse.streamingData.formats.length; i++)
        {
          if(ytInitialPlayerResponse.streamingData.formats[i].height > bestQuality)
          {
            bestQuality = ytInitialPlayerResponse.streamingData.formats[i].height;
            bestLink = ytInitialPlayerResponse.streamingData.formats[i].url;
          }
        }
    ytVideoLoader.res = bestQuality;
    return bestLink;
  },
};
ytVideoLoader.WaitLoadDom(window.document);
