namespace Kanafka.Admin.Domain.Enums;

public enum FailedMessageState
{
    New = 1,
    Reproducing = 2,
    NotReproduced = 3,
    Archived = 4
}