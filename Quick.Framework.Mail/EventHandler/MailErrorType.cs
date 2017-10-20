﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Quick.Framework.Mail.EventHandler
{
    public enum MailErrorType
    {
        GetQueueCount,
        Enqueue,
        Dequeue,
        UpdateFailure,
        Delete,
        GetNextSendInterval,
        SendMail
    }

}
