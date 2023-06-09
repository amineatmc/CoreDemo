﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message2>
    {
        List<Message2> GetInboxLİstByWriter(int p);
        List<Message2> GetListWithSendMessageByWriter(int p);
    }
}
