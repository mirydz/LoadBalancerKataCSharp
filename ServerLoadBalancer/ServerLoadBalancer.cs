﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoadBalancer
{
    public class ServerLoadBalancer
    {
        public void Balance(Server[] servers, Vm[] vms)
        {
            foreach (var vm in vms)
            {
                servers[0].AddVm(vm);
            }
        }
    }
}
