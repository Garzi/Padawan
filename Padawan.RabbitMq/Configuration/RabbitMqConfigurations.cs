using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;

namespace Padawan.RabbitMq.Configuration
{

    internal  class RabbitMqConfiguration
    {
        public string Url { get; set; }  = "rabbitmq://localhost";
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Nodes { get; set; }
        public RetryPolicyConfiguration RetryPolicy { get; set; }
        public CircuitBreakerConfiguration CircuitBreaker { get; set; }
        public RateLimiterConfiguration RateLimiter { get; set; }

        public bool DelayedExchangeMessageScheduler { get; set; }
        public int ConcurrentMessageLimit { get; set; }
    }

    
    internal class RetryPolicyConfiguration
    {
        public IncrementalConfiguration Incremental { get; set; }
    }

    internal class IncrementalConfiguration
    {
        public int RetryLimit { get; set; }
        public int InitialInterval { get; set; }
        public int IntervalIncrement { get; set; }
    }

    internal class CircuitBreakerConfiguration
    {
        public int TripThreshold { get; set; }
        public int ActiveThreshold { get; set; }
        public int ResetInterval { get; set; }
        public int TrackingPeriod { get; set; }
        
    }
    internal class RateLimiterConfiguration
    {
        public int RateLimit { get; set; }
        public int Interval { get; set; }
    }

}
