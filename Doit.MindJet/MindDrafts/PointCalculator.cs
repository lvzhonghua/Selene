using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doit.MindJet.MindDrafts
{
    /// <summary>
    /// 点位计算器
    /// </summary>
    class PointCalculator
    {
        public static ConnectionPoints GetConnectionPoints(MindShape from, MindShape to)
        {
            ConnectionPoints connectionPoints = new ConnectionPoints();

            RectangleF boundsOfFrom = from.Bounds;
            RectangleF boundsOfTo = to.Bounds;

            if (boundsOfFrom.Right <= boundsOfTo.Left)
            {
                connectionPoints.FromPoint = from.RightLinker.Location;
                connectionPoints.ToPoint = to.LeftLinker.Location;
                connectionPoints.P2 = new PointF((connectionPoints.FromPoint.X + connectionPoints.ToPoint.X) / 2, connectionPoints.FromPoint.Y);
                connectionPoints.P3 = new PointF((connectionPoints.FromPoint.X + connectionPoints.ToPoint.X) / 2, connectionPoints.ToPoint.Y);
            }

            if (boundsOfFrom.Left >= boundsOfTo.Right)
            {
                connectionPoints.FromPoint = from.LeftLinker.Location;
                connectionPoints.ToPoint = to.RightLinker.Location;
                connectionPoints.P2 = new PointF((connectionPoints.FromPoint.X + connectionPoints.ToPoint.X) / 2, connectionPoints.FromPoint.Y);
                connectionPoints.P3 = new PointF((connectionPoints.FromPoint.X + connectionPoints.ToPoint.X) / 2, connectionPoints.ToPoint.Y);
            }

            if (boundsOfFrom.Top >= boundsOfTo.Bottom)
            {
                connectionPoints.FromPoint = from.TopLinker.Location;
                connectionPoints.ToPoint = to.BottomLinker.Location;
                connectionPoints.P2 = new PointF(connectionPoints.FromPoint.X, (connectionPoints.FromPoint.Y + connectionPoints.ToPoint.Y)/2);
                connectionPoints.P3 = new PointF(connectionPoints.ToPoint.X, (connectionPoints.FromPoint.Y + connectionPoints.ToPoint.Y) / 2);
            }

            if (boundsOfFrom.Bottom <= boundsOfTo.Top)
            {
                connectionPoints.FromPoint = from.BottomLinker.Location;
                connectionPoints.ToPoint = to.TopLinker.Location;
                connectionPoints.P2 = new PointF(connectionPoints.FromPoint.X, (connectionPoints.FromPoint.Y + connectionPoints.ToPoint.Y) / 2);
                connectionPoints.P3 = new PointF(connectionPoints.ToPoint.X, (connectionPoints.FromPoint.Y + connectionPoints.ToPoint.Y) / 2);
            }

            return connectionPoints;
        }
    }

    
}
