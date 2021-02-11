using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scool_cash_manager
{
    class PDFBackgroundHelper :PdfPageEventHelper
    {
        protected float startpos = -1;
        protected bool title = true;

        public void SetTitle(bool title)
        {
            this.title = title;
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Rectangle pagesize = document.PageSize;
            ColumnText.ShowTextAligned(
                writer.DirectContent,
                Element.ALIGN_CENTER,
                new Phrase(writer.PageNumber.ToString()),
                (pagesize.Left + pagesize.Right) / 2,
                pagesize.Bottom + 15,
                0);

            if (startpos != -1)
            {
                OnParagraphEnd(writer, document,
                    pagesize.GetBottom(document.BottomMargin));
            }

            startpos = pagesize.GetTop(document.TopMargin);
        }


        public override void OnParagraph(PdfWriter writer, Document document,
        float paragraphPosition)
        {
            startpos = paragraphPosition;
        }

    }
}
